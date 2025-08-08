import axios from 'axios';
import applyInterceptors from './interceptors';

const BaseUrl = ' http://localhost:5293';

const axiosClient = axios.create({
    baseURL: BaseUrl,
    headers: {
        'Content-Type': 'application/json',
    },
    timeout: 10000,
    'withCredentials': true
});

applyInterceptors(axiosClient);

export default axiosClient;