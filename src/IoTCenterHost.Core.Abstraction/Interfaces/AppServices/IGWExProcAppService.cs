using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTCenterHost.Core.Abstraction.AppServices
{
    public interface IGWExProcAppService
    {
        /// <summary>
        /// 执行扩展模块中的一个命令
        /// </summary>
        /// <param name="ModuleNm">模块名称.GWExProc表中的Proc_Module</param>
        /// <param name="cmd1">参数1.GWExProcCmd表中的main_instruction</param>
        /// <param name="cmd2">参数2.GWExProcCmd表中的minor_instruction</param>
        /// <param name="cmd3">参数3.GWExProcCmd表中的value</param> 
        void DoExProcSetParm(string ModuleNm, string cmd1, string cmd2, string cmd3);
    }
}
