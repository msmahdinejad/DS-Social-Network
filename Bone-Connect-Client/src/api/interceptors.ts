import { AxiosInstance, AxiosResponse, InternalAxiosRequestConfig } from "axios";

const applyInterceptors = (axiosClient: AxiosInstance) => {
    axiosClient.interceptors.request.use(
        (config: InternalAxiosRequestConfig) => {
            return config;
        },
        (error) => {
            return Promise.reject(error);
        }
    );

    axiosClient.interceptors.response.use(
        (response: AxiosResponse) => {
            return response;
        },
        (error) => {
            const status = error.response?.status;
            if (status === 401 || status === 403 || status === 500) {
                axiosClient.post('/User/logout')
                window.location.href = '/login'
                localStorage.clear()
            }

            return Promise.reject(error);
        }
    );
}

export default applyInterceptors;