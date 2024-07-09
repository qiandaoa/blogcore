using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Model.Models
{
    public class Advertisement
    {
        // ID
        public int Id {get;set;}
        // 广告图片
        public string ImgUrl{get;set;}
        // 广告标题
        public string Iitle {get;set;}
        // 备注
        public string Remark {get;set;}
        // 创建时间
        public DateTime Createdate {get;set;} = DateTime
    }
}