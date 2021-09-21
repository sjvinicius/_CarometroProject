import axios from 'axios'

const api = axios.create({

    baseURL : 'http://localhost:5000/v1/account'

})

export default api;