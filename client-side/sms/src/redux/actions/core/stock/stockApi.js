import axios from "axios";

const baseUrl = "https://localhost:44388/api/"

// const instance = axios.create({
//     baseUrl,
//     timeout:1000,
//     headers:{'Athorization':'Bearer '+ localStorage.getItem("JwtBearerToken")}
// })

const config = {
    headers: {
       'Authorization': "Bearer " + localStorage.getItem("JwtBearerToken"),
       
    },

    
 }


export default {

    stockHttp(url = baseUrl + 'stock/') {
        return {
            fetchAll: () => axios.get(url+"Get/",config),
            fetchById: id => axios.get(url + id),
            fetchByDistritId: id => axios.get(url+"SearchByDistrictId/" + id),
            fetchByDivisonId: id => axios.get(url+"SearchByDivisonId/" + id),
            fetchByUpazilaId: id => axios.get(url+"SearchByUpazilaId/" + id),
            create: newRecord =>axios.post(url+"create/", newRecord),
            update: (id, updateRecord) => axios.put(url+"update/", updateRecord),
            delete: id => axios.delete(url+"PermanentDeleteById/" + id)
        }
    }
}