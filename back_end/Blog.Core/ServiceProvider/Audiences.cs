namespace Blog.Core.ServiceProvider
{
    public static class Audiences
    {
        private static IDictionary<string,string> _audiences = new Dictionary<string,string>(); // 创建一个存放键值对的属性
        public static string UpdateAudience(string userNo)
        {
            if (string.IsNullOrWhiteSpace(userNo)) // 检查接受值是否为空字符串和是否为null还有是否只有空格
            {
                return string.Empty; // 如果以上条件都满足就返回一个空字符
            }
            var audience = $"{userNo}_{DateTime.Now}"; // 将接受的字符串与现在电脑的时间经行结合
            _audiences[userNo] = audience; // userNo表示键,audience表示值
            return audience; // 返回更新用户和更新时间
        }
        // 是否属于最新的用户
        public static bool IsNewestAudience(string audience)
        {
            if (string.IsNullOrWhiteSpace(audience)) // 用于检查接受的接受的用户和时间
            {
                return false;
            }
            var userName = audience.Split("_")[0]; // 将用户名和时间分离
            if (!_audiences.ContainsKey(userName)) // 从这个键值对属性中检查是否有这个交userName的键值对
            {
                return false;
            }
            return _audiences[userName] == audience; // 如果有就与接受的用户经行比对
        }
    }
}
