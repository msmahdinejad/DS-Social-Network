import axiosClient from "../api/axiosClient";
import { ChangePassword, ProfileForm } from "../types/types";


const userService = {

    getUserByAuth: async () => {
        const response = await axiosClient.get('/User')
        return response.data
    },


    deleteUser: async () => {
        const response = await axiosClient.delete('/User')
        return response.data
    },

    editUser: async ({ email, firstName, lastName, username, profilePic }: ProfileForm) => {
        const response = await axiosClient.put('/User', {
            email,
            firstName,
            lastName,
            username,
            profilePic
        })
        return response.data
    },


    getUserById: async (username: string) => {
        const response = await axiosClient.get(`/User/${username}`)
        return response.data
    },

    changePassword: async ({ newPassword, oldPassword }: ChangePassword) => {
        const response = await axiosClient.patch(`/User/password`, {
            newPassword,
            oldPassword
        })

        return response.data
    },


    logout: async () => {
        const response = await axiosClient.post('/User/logout')
        return response.data
    },

    addConnection: async (username: string) => {
        const response = await axiosClient.post(`/User/connect/${username}`)
        return response.data
    },

    removeConnection: async (username: string) => {
        const response = await axiosClient.delete(`/User/connect/${username}`)
        return response.data
    }

}

export default userService