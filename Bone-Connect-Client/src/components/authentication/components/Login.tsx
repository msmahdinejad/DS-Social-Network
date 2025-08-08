import React from "react";
import { useForm } from "react-hook-form";
import { AuthenticationType } from "../types/type";
import { Link, useNavigate } from "react-router-dom";
import { useMutation } from "@tanstack/react-query";
import { Toaster, toast } from "react-hot-toast";
import type { AuthLogin } from "../../../types/types";
import authService from "../../../services/authService";

import type { AxiosError } from "axios";
import useAuthStore from "../../../stores/useAuthStore";

const Login: React.FC = () => {
  const navigate = useNavigate();
  const { login } = useAuthStore();
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<AuthenticationType>();

  const { mutate, isPending } = useMutation({
    mutationFn: (data: AuthLogin) => authService.authLogin(data),
    mutationKey: ["loginUser"],
    onSuccess: () => {
      toast.success("Login successful! 🎉");
      reset();
      login();
      navigate("/profile");
    },
    onError: (error: AxiosError) => {
      const status = error.response?.status;
      toast.error(
        status === 400
          ? "Username is incorrect"
          : "Login failed. Please try again."
      );
    },
  });

  const onSubmit = (data: AuthLogin) => {
    mutate(data);
  };

  return (
    <div className="w-full h-full flex flex-col  justify-center items-start bg-white px-72 pt-5 gap-10">
      <Toaster position="top-center"></Toaster>
      <img src="/assets/images/formIcon.svg" alt="Form Icon" />
      <div className="w-full ">
        <div className=" flex flex-col justify-start items-center w-full ">
          {/* Header Section */}
          <div className="flex flex-col justify-start items-start gap-9 w-full text-center mb-10">
            <p className="text-2xl font-bold text-[3.6rem] text-[#525252]">
              Login to your Account
            </p>
            <p className="text-[1.6rem] text-[#525252]">
              See what is going on in Connect Bone
            </p>
          </div>

          {/* Form Section */}
          <form
            onSubmit={handleSubmit(onSubmit)}
            className="w-full flex flex-col gap-6"
          >
            {/* UserName Field */}
            <div className="flex flex-col gap-2">
              <label
                className="text-[#828282] font-semibold text-[1.4rem]"
                htmlFor="username"
              >
                UserName
              </label>
              <input
                {...register("username", { required: "Username is required" })}
                type="text"
                id="username"
                placeholder="Enter Your Usernname"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.username && (
                <span className="text-sm text-red-500">
                  {errors.username.message}
                </span>
              )}
            </div>

            {/* Password Field */}
            <div className="flex flex-col gap-2">
              <label
                className="text-[#828282] font-semibold text-[1.4rem]"
                htmlFor="password"
              >
                Password
              </label>
              <input
                {...register("password", { required: "Password is required" })}
                type="password"
                id="password"
                placeholder="Enter Password"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.password && (
                <span className="text-sm text-red-500">
                  {errors.password.message}
                </span>
              )}
            </div>

            {/* Remember Me and Forgot Password */}
            <div className="flex items-center justify-between w-full text-sm text-[#828282]">
              <label className="flex items-center gap-2">
                <input
                  type="checkbox"
                  className="form-checkbox border border-[#DED2D9] text-blue-500 focus:ring-blue-400"
                />
                Remember Me
              </label>
              <a href="#" className="text-[#7F265B] hover:underline">
                Forgot Password?
              </a>
            </div>

            {/* Submit Button */}
            <button
              type="submit"
              className="w-full py-3 bg-[#7F265B] text-white text-[1.6rem] rounded-lg font-medium hover:bg-[#7c2c5cf8] transition flex justify-center items-center"
              disabled={isPending}
            >
              {isPending ? (
                <svg
                  className="animate-spin h-5 w-5 mr-3 border-4 border-white border-t-transparent rounded-full"
                  viewBox="0 0 24 24"
                />
              ) : (
                "Login"
              )}
            </button>
          </form>

          {/* Footer Section */}
          <p className="font-semibold text-[1.8rem] text-[#828282] text-center mt-6">
            Not Registerd Yet?{" "}
            <Link
              to="/register"
              className="font-semibold text-[1.8rem]  text-[#7F265B] hover:underline"
            >
              Create an account
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};

export default Login;
