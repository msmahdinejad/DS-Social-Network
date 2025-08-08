import { useForm } from "react-hook-form";
import useGetUser from "../../hooks/useGetUser";
import { useMutation } from "@tanstack/react-query";
import userService from "../../services/userService";
import type { ProfileForm, ChangePassword } from "../../types/types";
import { toast, Toaster } from "react-hot-toast";
import { AxiosError } from "axios";
import { useEffect } from "react";

const Setting = () => {
  const { userInfo, refetch } = useGetUser();

  const { reset } = useForm();

  const { register: registerProfile, handleSubmit: handleSubmitProfile } =
    useForm<ProfileForm>();

  const { register: registerPassword, handleSubmit: handleSubmitPassword } =
    useForm<ChangePassword>();

  const onSubmitProfile = (data: ProfileForm) => {
    mutateProfile(data);
    reset();
  };

  const onSubmitPassword = (data: ChangePassword) => {
    mutatePassword(data);
    reset();
  };

  useEffect(() => {
    console.log(userInfo);
  }, [userInfo]);

  const { mutate: mutateProfile } = useMutation({
    mutationFn: (data: ProfileForm) => userService.editUser(data),
    mutationKey: ["editUser"],
    onSuccess: () => {
      toast.success("Done 🎉");
      refetch();
      reset();
    },
    onError: (error: AxiosError) => {
      toast.error(
        error?.status === 400
          ? "UserName is wrong"
          : "Registration failed. Try again."
      );
    },
  });

  const { mutate: mutatePassword } = useMutation({
    mutationFn: (data: ChangePassword) => userService.changePassword(data),
    mutationKey: ["changePassword"],
    onSuccess: () => {
      toast.success("password was changed 🎉");
      refetch();
      reset();
    },
    onError: (error: AxiosError) => {
      toast.error(
        error?.status === 400
          ? "UserName is wrong"
          : "Registration failed. Try again."
      );
    },
  });

  return (
    <div className="flex justify-center items-center w-full h-full p-4">
      <Toaster position="top-center"></Toaster>
      <div className="h-fit w-1/2 backdrop-blur-lg bg-white/10 p-6 rounded-2xl shadow-lg border border-white/20">
        <h2 className="text-2xl font-bold text-white text-center pb-4">
          Settings
        </h2>

        {/* Profile Form */}
        <form
          onSubmit={handleSubmitProfile(onSubmitProfile)}
          className="flex flex-col justify-start items-center gap-6"
        >
          {["profilePic", "username", "firstName", "lastName", "email"].map(
            (field) => (
              <input
                key={field}
                type="text"
                {...registerProfile(field as keyof ProfileForm)}
                placeholder={`Enter ${
                  field.charAt(0).toUpperCase() + field.slice(1)
                }`}
                defaultValue={userInfo?.[field]}
                className="text-[1.6rem] w-full p-3 bg-white/20 text-black rounded-lg outline-none placeholder-black/50"
              />
            )
          )}

          <button
            type="submit"
            className="text-[1.6rem] w-full bg-blue-500 hover:bg-blue-700 transition p-3 text-white font-italic rounded-lg"
          >
            Save Profile
          </button>
        </form>

        <hr className="my-6 border-white/20 w-full" />

        {/* Password Change Form */}
        <form
          onSubmit={handleSubmitPassword(onSubmitPassword)}
          className="flex flex-col justify-start items-center gap-6"
        >
          {["oldPassword", "newPassword"].map((field) => (
            <input
              key={field}
              type="text"
              {...registerPassword(field as keyof ChangePassword)}
              placeholder={`Enter ${
                field === "oldPassword" ? "Current Password" : "New Password"
              }`}
              className="text-[1.6rem] w-full p-3 bg-white/20 text-black rounded-lg outline-none placeholder-black/50"
            />
          ))}

          <button
            type="submit"
            className="text-[1.6rem] w-full bg-red-500 hover:bg-red-700 transition p-3 text-white font-italic rounded-lg"
          >
            Change Password
          </button>
        </form>
      </div>
    </div>
  );
};

export default Setting;
