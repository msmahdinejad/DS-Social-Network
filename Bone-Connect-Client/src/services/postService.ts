import axiosClient from "../api/axiosClient";

export type EditPost = {
    postId: string,
    caption: string,
    pictures: string[]
}

export type CreatePost = {
    caption: string,
    pictures: string[]
}


const postService = {
    getPostById: async (id: string) => {
        const response = await axiosClient.get(`/Post/${id}`)
        return response.data
    },

    deletePostById: async (id: string) => {
        const response = await axiosClient.delete(`/Post/${id}`)
        return response.data
    },

    editPostById: async ({ postId, caption, pictures }: EditPost) => {
        const response = await axiosClient.put(`/Post/${postId}`, {
            caption,
            pictures
        })
        return response.data
    },

    createPost: async ({ caption, pictures }: CreatePost) => {
        const response = await axiosClient.post(`/Post`, {
            caption,
            pictures
        })
        return response.data
    },


}


export default postService