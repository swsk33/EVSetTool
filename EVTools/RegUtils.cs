using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EVTools
{
    class RegUtils
    {
        //冗余版本信息
        private static readonly string[] NOT_ADD_VERSION_VALUE = { "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8" };
        //jdk版本列表
        public static Dictionary<string, string> jdkVersions = new Dictionary<string, string>();
        //JAVA_HOME变量名称
        private static readonly string JAVA_HOME_NAME = "%JAVA_HOME%";
        //classpath变量值
        private static readonly string CLASSPATH_VALUE = ".;" + JAVA_HOME_NAME + @"\lib\dt.jar;" + JAVA_HOME_NAME + @"\lib\tools.jar";
        //追加Path变量值
        private static readonly string ADD_PATH_VALUE = JAVA_HOME_NAME + @"\bin";

        /// <summary>
        /// 判断注册表项是否存在
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="name">项的完整路径</param>
        /// <returns></returns>
        private static bool IsRegExists(RegistryKey key, string name)
        {
            bool isExists = true;
            try
            {
                RegistryKey registryKey = key.OpenSubKey(name);
                registryKey.Close();
            }
            catch (Exception)
            {
                isExists = false;
            }
            return isExists;
        }

        /// <summary>
        /// 判断注册表某一项下的某个值是否存在
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="name">项名</param>
        /// <param name="valueName">值名</param>
        /// <returns></returns>
        private static bool IsRegValueExists(RegistryKey key, string name, string valueName)
        {
            bool isExists = false;
            if (IsRegExists(key, name))
            {
                RegistryKey registryKey = key.OpenSubKey(name);
                string[] subValues = registryKey.GetValueNames();
                foreach (string eachValueName in subValues)
                {
                    Console.WriteLine(eachValueName);
                    if (eachValueName.Equals(valueName))
                    {
                        isExists = true;
                        break;
                    }
                }
            }
            return isExists;
        }

        /// <summary>
        /// 检测已安装jdk版本，信息储存至RegUtils类的全局静态变量jdkVersions中。
        /// </summary>
        public static void GetJDKVersion()
        {
            jdkVersions.Clear();
            RegistryKey key = Registry.LocalMachine;
            if (!IsRegExists(key, @"SOFTWARE\JavaSoft\Java Development Kit") && !IsRegExists(key, @"SOFTWARE\JavaSoft\JDK"))
            {
                return;
            }
            //检测jdk8及其以下版本
            RegistryKey jdkOldVersionsKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit");
            string[] jdkOldVersions = jdkOldVersionsKey.GetSubKeyNames();
            foreach (string version in jdkOldVersions)
            {
                if (Array.IndexOf(NOT_ADD_VERSION_VALUE, version) == -1)
                {
                    RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit\" + version);
                    string path = jdkVersionKey.GetValue("JavaHome").ToString();
                    jdkVersions.Add(version, path);
                    jdkVersionKey.Close();
                }
            }
            //检测jdk9及其以上版本
            RegistryKey jdkNewVersionsKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\JDK");
            string[] jdkNewVersions = jdkNewVersionsKey.GetSubKeyNames();
            foreach (string version in jdkNewVersions)
            {
                RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\JDK\" + version);
                string path = jdkVersionKey.GetValue("JavaHome").ToString();
                jdkVersions.Add(version, path);
                jdkVersionKey.Close();
            }
            jdkOldVersionsKey.Close();
            jdkNewVersionsKey.Close();
        }

        /// <summary>
        /// 设定JDK环境变量
        /// </summary>
        /// <param name="javaPath">jdk所在的路径</param>
        /// <param name="isJDK9AndAbove">是否是jdk9及其以上版本的jdk</param>
        public static void SetJDKValue(string javaPath, bool isJDK9AndAbove)
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey EVKey = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
            EVKey.SetValue("JAVA_HOME", javaPath);
            if (isJDK9AndAbove)
            {
                if (IsRegValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath"))
                {
                    EVKey.DeleteValue("classpath");
                }
            }
            else
            {
                if (!IsRegValueExists(key, @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "classpath") || !EVKey.GetValue("classpath").Equals(CLASSPATH_VALUE))
                {
                    EVKey.SetValue("classpath", CLASSPATH_VALUE, RegistryValueKind.ExpandString);
                }
            }
            string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
            if (!pathValue.Contains(ADD_PATH_VALUE))
            {
                if (pathValue.EndsWith(";"))
                {
                    EVKey.SetValue("Path", pathValue + ADD_PATH_VALUE);
                }
                else
                {
                    EVKey.SetValue("Path", pathValue + ";" + ADD_PATH_VALUE);
                }
            }
            EVKey.Close();
            MessageBox.Show("设置完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。有的电脑设置了环境变量可能需要重启才能生效！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void AddValueToPath(string value)
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey EVKey = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
            string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
            if (pathValue.Contains(value))
            {
                MessageBox.Show("这个值已经存在于Path中！无需重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pathValue.EndsWith(";"))
            {
                EVKey.SetValue("Path", pathValue + value);
            }
            else
            {
                EVKey.SetValue("Path", pathValue + ";" + value);
            }
            EVKey.Close();
            MessageBox.Show("设置完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。有的电脑设置了环境变量可能需要重启才能生效！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
