namespace Blog.Core.Dto
{
    public class UserProviderDto
    {
        public UserProviderDto(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public string ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
