// axios.get("url",{请求体}).then().catch() 简化axios
import axios from "axios"

var root = "后端接口地址"
function toType(obj) {
    return ({}).toString
}


// ({}) : 表示空对象,method:方法名(get，post,put,delete)，params(地址后面的参数)
// 封住axios的方法
function apiAxios (method,url,params,success,fai)
{

}