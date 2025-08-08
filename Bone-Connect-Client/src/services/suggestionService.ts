import axiosClient from "../api/axiosClient"


const suggestionService = {
    getSuggestions: async () => {
        const response = await axiosClient.get('/Suggestion')
        return response.data
    }
}

export default suggestionService