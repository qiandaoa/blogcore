// axios.get("url",{请求体}).then().catch() 简化axios
import axios from "axios"
import { id } from "element-plus/es/locales.mjs";

var root = "后端接口地址"
// ({}) : 表示空对象,method:方法名(get，post,put,delete)，url(除了root后面的路径)，params(向api发送的数据),success成功,failure失败
function apiAxios(method, url, params, success, failure) {
    if (params) {
        params = filterNull(params); //上面定义的方法
    }
    axios({
        method: method,// get,post,delete,put
        url: root + url, // 请求地址
        data: method === 'POST' || method === 'PUT' ? params : null, // 如果请求方法是post或者put，则将params作为data
        params: method === 'GET' || method === 'DELETE' ? params : null, // 如果请求方法是get或者delete，则将params作为params
        // headers: { "Authorization": "Bearer xxxxxxx" }
    }).then(res => {
        if (res.data.success === true) {
            success(res.data);
        } else {
            failure(res.data);
        }
    })
}

// 暴露文件
export default {
    get:function (url,params,success,failure) {
        return apiAxios("GET",url,params,success,failure)
    },
    psot: function (url, params, success, failure) {
        return apiAxios("GE", url, params, success, failure)
    },
    get: function (url, params, success, failure) {
        return apiAxios("GET", url, params, success, failure)
    },
    get: function (url, params, success, failure) {
        return apiAxios("GET", url, params, success, failure)
    },

}