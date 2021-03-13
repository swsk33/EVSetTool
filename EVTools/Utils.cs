using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace EVTools
{
    class Utils
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
        /// 运行setx命令设定环境变量
        /// </summary>
        /// <param name="varName">设定变量名</param>
        /// <param name="value">变量值</param>
        /// <param name="isSysVar">是否是系统变量</param>
        private static void RunSetx(string varName, string value, bool isSysVar)
        {
            string args = "\"" + varName + "\" " + "\"" + value + "\"";
            if (isSysVar)
            {
                args = args + " /m";
            }
            Process process = new Process();
            process.StartInfo.FileName = "setx";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            try
            {
                process.Start();
                _ = process.StandardOutput.ReadToEnd();
                _ = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch
            {
                // none
            }
            finally
            {
                process.Close();
            }
        }

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
            //检测jdk8及其以下版本
            if (IsRegExists(key, @"SOFTWARE\JavaSoft\Java Development Kit"))
            {
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
                jdkOldVersionsKey.Close();
            }
            //检测jdk9及其以上版本
            if (IsRegExists(key, @"SOFTWARE\JavaSoft\JDK"))
            {
                RegistryKey jdkNewVersionsKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\JDK");
                string[] jdkNewVersions = jdkNewVersionsKey.GetSubKeyNames();
                foreach (string version in jdkNewVersions)
                {
                    RegistryKey jdkVersionKey = key.OpenSubKey(@"SOFTWARE\JavaSoft\JDK\" + version);
                    string path = jdkVersionKey.GetValue("JavaHome").ToString();
                    jdkVersions.Add(version, path);
                    jdkVersionKey.Close();
                }
                jdkNewVersionsKey.Close();
            }
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
            RunSetx("JAVA_HOME", javaPath, true);
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
                    RunSetx("classpath", CLASSPATH_VALUE, true);
                }
            }
            string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
            if (!pathValue.Contains(ADD_PATH_VALUE))
            {
                if (pathValue.EndsWith(";"))
                {
                    RunSetx("Path", pathValue + ADD_PATH_VALUE, true);
                }
                else
                {
                    RunSetx("Path", pathValue + ";" + ADD_PATH_VALUE, true);
                }
            }
            EVKey.Close();
            MessageBox.Show("设置完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 把指定值加入到Path环境变量中去
        /// </summary>
        /// <param name="value">指定值</param>
        public static void AddValueToPath(string value)
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey EVKey = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
            string pathValue = EVKey.GetValue("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
            if (pathValue.Contains(value + ";") || pathValue.EndsWith(value))
            {
                MessageBox.Show("这个值已经存在于Path中！无需重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pathValue.EndsWith(";"))
            {
                RunSetx("Path", pathValue + value, true);
            }
            else
            {
                RunSetx("Path", pathValue + ";" + value, true);
            }
            EVKey.Close();
            MessageBox.Show("设置完成！若发现环境变量并没有成功设定，请退出程序然后右键-以管理员身份运行此程序重试。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}