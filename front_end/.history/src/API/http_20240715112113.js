// axios.get("url",{请求体}).then().catch() 简化axios
import axios from "axios"

var root = "后端接口地址"
function toType(obj) {
    return ({}).toString
}


// ({}) : 表示空对象,method:方法名(get，post,put,delete)，url(除了root后面的路径)，params(向api发送的数据),success成功,failure失败

// axios({
//     method: 'post',
//     url: '/user/12345',
//     params: {
//          id: 123,
//          name: 'John'
//      }   https://example.com/api/users?id=123&name=Joh相当于id=123&name=Joh
//     data: {
//         firstName: 'Fred',
//         lastName: 'Flintstone'
//     },
//     baseURL: 'https://some-domain.com/api/',
//     headers: {"Authorization":"Bearer xxxxxxx"}
// });
// 封住axios的方法
function apiAxios (method,url,params,success,failure)
{
    if (params) {
        params = filterNull(params); //params这个是去除null的函数
    }
    axios({
        method:method,// get,post,delete,put
        url:root+url, // 
    })
}