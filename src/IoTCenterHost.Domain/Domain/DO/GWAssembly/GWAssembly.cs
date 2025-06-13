using IoTCenterHost.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTCenterHost.AppServices.Domain.DO
{
    /// <summary>
    /// 协议插件管理
    /// </summary>
    public class GWAssembly
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 主键字符串
        /// </summary>
        public string StrId { get { return Id.ToString(); } }
        /// <summary>
        /// 名称
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public PluginType Assemblytype { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string Attachment { get; set; }
        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[]? Blob { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        public int Enabled { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public int? Deletedmark { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string? Version { get; set; }
        /// <summary>
        /// 创建于
        /// </summary1
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string? Createdby { get; set; }
        /// <summary>
        ///修改于 
        /// </summary>
        public DateTime? ModifiedAt { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string? ModifiedBy { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; } 
    }
}
