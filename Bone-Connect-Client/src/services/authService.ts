import axiosClient from "../api/axiosClient";
import type { AuthLogin, AuthRegister } from "../types/types";

const authService = {

    authLogin: async ({ password, username }: AuthLogin) => {
        const response = await axiosClient.post(`/Auth/login`, {
            username,
            password,
        })

        return response.data
    },

    authRegister: async ({ email, firstName, lastName, password, username, profilePic }: AuthRegister) => {
        const response = await axiosClient.post(`/Auth/register`, {
            email,
            firstName,
            lastName,
            password,
            username,
            profilePic: 'https://s6.uupload.ir/files/screenshot_2025-01-26_145927_l7go.png'
        })

        return response.data
    }




}


export default authService
