import { useState } from "react";
import { useForm } from "react-hook-form";
import { useMutation } from "@tanstack/react-query";
import userService from "../../services/userService";
import { User } from "../../types/types";
import { Link } from "react-router-dom";
import useGetUser from "../../hooks/useGetUser";
const Explore = () => {
  const { userInfo, refetch } = useGetUser();
  const { register, handleSubmit, reset } = useForm<{ username: string }>();
  const [user, setUser] = useState<User | null>(null);
  const [errorMessage, setErrorMessage] = useState("");

  const { mutate, isPending } = useMutation({
    mutationFn: (id: string) => userService.getUserById(id),
    mutationKey: ["getUserById"],
    onSuccess: (data) => {
      setUser(data);
      setErrorMessage("");
      refetch();
      reset();
    },
    onError: () => {
      setUser(null);
      setErrorMessage("No user found with this name.");
    },
  });

  const { mutate: connectUser } = useMutation({
    mutationFn: (id: string) => userService.addConnection(id),
    mutationKey: ["connectToUser"],
    onSuccess: (data) => {
      setUser(data);
      setErrorMessage("");
      refetch();
      reset();
    },
  });

  const onSubmit = (data: { username: string }) => {
    mutate(data.username);
  };

  return (
    <div className=" flex flex-col items-center justify-center w-full h-full p-6">
      {/* Glassy Form Container */}
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="flex-col w-1/2 flex gap-4 bg-white/10 backdrop-blur-lg p-6 rounded-xl shadow-xl border border-white/20"
      >
        <input
          {...register("username", { required: true })}
          type="text"
          placeholder="Enter username..."
          className="text-[1.6rem] border-none bg-white/20 p-3 rounded-lg text-black placeholder-black focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
        <button
          type="submit"
          className="bg-blue-500 text-white text-[1.6rem] px-6 py-3 rounded-lg hover:bg-blue-600 transition font-semibold "
          disabled={isPending}
        >
          {isPending ? "Searching..." : "Search"}
        </button>
      </form>

      {/* Error Message */}
      {errorMessage && (
        <p className="mt-4 text-red-600 text-[1.6rem]  font-medium bg-white/10 p-2 px-4 rounded-lg backdrop-blur-md">
          {errorMessage}
        </p>
      )}

      {/* User Info Card */}

      {user && (
        <div className=" w-1/4 mt-6 p-6 bg-white/10 backdrop-blur-lg border border-white/20 rounded-xl shadow-lg  text-center">
          <div className="gap-4 flex justify-start items-center">
            <img
              className="rounded-full w-[7rem] h-[7rem]"
              src={user.profilePic}
              alt=""
            />
            <h3 className="text-[1.6rem] font-semibold text-black">
              Username : {user.username}
            </h3>
          </div>
          <div className="flex justify-end items-center gap-2">
            {userInfo?.username ===
            user.username ? null : userInfo?.connections.some(
                (item) => item.username === user.username
              ) ? null : (
              <button
                onClick={() => {
                  connectUser(user.username);
                }}
                className="text-[1.6rem] px-4 py-2 bg-blue-500 text-white rounded-xl hover:bg-blue-600"
              >
                Connect
              </button>
            )}

            <Link
              className="text-[1.6rem] px-4 py-2 bg-red-500 text-white rounded-xl hover:bg-blue-600"
              to={
                userInfo?.username === user.username
                  ? "/profile"
                  : `/profile/${user.username}`
              }
            >
              View Profile
            </Link>
          </div>
        </div>
      )}
    </div>
  );
};

export default Explore;
