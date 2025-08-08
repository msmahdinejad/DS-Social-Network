import { useQuery } from "@tanstack/react-query"
import userService from "../services/userService"
import { User } from "../types/types"


const useGetUser = () => {

    const { data: userInfo, refetch } = useQuery<User>({
        queryKey: ['getUserInfo'],
        queryFn: () => userService.getUserByAuth()
    })

    return {
        userInfo,
        refetch
    }
}

export default useGetUser