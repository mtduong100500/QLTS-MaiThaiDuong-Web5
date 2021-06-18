import axios from 'axios'

export default () => {
    return axios.create({
        baseURL: 'https://localhost:44331/api',
        withCredentialsL: false,
        headers:{
            Accept: "application/json",
            "Content-Type": "application/json"
        }
    })
}