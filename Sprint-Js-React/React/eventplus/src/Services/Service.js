import axios from "axios";

const apiPort = "5000";

//API Local
// const localApi = `http://localhost:${apiPort}/api`

//API Azure 
const externaApi = `https://webapifernando.azure-api.net/api` 

const api = axios.create({
    baseURL : externaApi
});

export default api;