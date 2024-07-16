// axios.get("url",{请求体}).then().catch() 简化axios
import axios from "axios"

var root = "后端接口地址"
function toType(obj) {
    return ({}).toString
}


// ({}) : 表示空对象,method:方法名(get，post,put,delete)，params(像api发送的数据),success成功,failure失败
// 封住axios的方法
function apiAxios (method,url,params,success,failure)
{

}