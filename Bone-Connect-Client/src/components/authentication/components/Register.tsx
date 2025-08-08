import React from "react";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import { Toaster, toast } from "react-hot-toast";
import type { AuthRegister } from "../../../types/types";
import { useMutation } from "@tanstack/react-query";
import authService from "../../../services/authService";
import { AxiosError } from "axios";
import { useNavigate } from "react-router-dom";
const Register: React.FC = () => {
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<AuthRegister>();

  const { mutate, isPending } = useMutation({
    mutationFn: (data: AuthRegister) => authService.authRegister(data),
    mutationKey: ["registerUser"],
    onSuccess: () => {
      toast.success("Registration successful! 🎉");
      reset();
      navigate("/login");
    },
    onError: (error: AxiosError) => {
      toast.error(
        error?.status === 400
          ? "UserName Already Exist"
          : "Registration failed. Try again."
      );
    },
  });

  const onSubmit = (data: AuthRegister) => {
    mutate(data);
  };

  return (
    <div className="w-full h-full flex flex-col justify-center items-start bg-white px-72 pt-5 gap-10">
      <Toaster position="top-center"></Toaster>
      <img src="../../../../public/assets/images/formIcon.svg" alt="" />
      <div className="w-full">
        <div className="flex flex-col justify-start items-center w-full">
          {/* Header Section */}
          <div className="flex flex-col justify-start items-start gap-9 w-full text-center mb-10">
            <p className="text-2xl font-bold text-[3.6rem] text-[#525252]">
              Create Your Account
            </p>
            <p className="text-[1.6rem] text-[#525252]">
              Join To The Connect Bone
            </p>
          </div>

          {/* Form Section */}
          <form
            onSubmit={handleSubmit(onSubmit)}
            className="w-full flex flex-col gap-6"
          >
            {/* Username Field */}
            <div className="flex flex-col gap-2">
              <label
                className="text-[#828282] font-semibold text-[1.4rem]"
                htmlFor="username"
              >
                Username
              </label>
              <input
                {...register("username", { required: "Username is required" })}
                type="text"
                id="username"
                placeholder="Enter Your Username"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.username && (
                <span className="text-sm text-red-500">
                  {errors.username.message}
                </span>
              )}
            </div>

            {/* FirstName */}
            <div className="flex flex-col gap-2">
              <label
                className="text-[#828282] font-semibold text-[1.4rem]"
                htmlFor="firstName"
              >
                FirstName
              </label>
              <input
                {...register("firstName", {
                  required: "Email is required",
                })}
                type="text"
                id="firstName"
                placeholder="Enter Your FirstName"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.firstName && (
                <span className="text-sm text-red-500">
                  {errors.firstName.message}
                </span>
              )}
            </div>

            {/* LastName */}
            <div className="flex flex-col gap-2">
              <label
                className="text-[#828282] font-semibold text-[1.4rem]"
                htmlFor="lastName"
              >
                LastName
              </label>
              <input
                {...register("lastName", {
                  required: "LastNmae is required",
                })}
                type="text"
                id="lastNmae"
                placeholder="Enter Your LastNmae"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.lastName && (
                <span className="text-sm text-red-500">
                  {errors.lastName.message}
                </span>
              )}
            </div>

            {/* Email */}
            <div className="flex flex-col gap-2">
              <label
                className="text-[#828282] font-semibold text-[1.4rem]"
                htmlFor="email"
              >
                Email
              </label>
              <input
                {...register("email", {
                  required: "Email is required",
                })}
                type="text"
                id="email"
                placeholder="Enter Your Email"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.email && (
                <span className="text-sm text-red-500">
                  {errors.email.message}
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
                {...register("password", {
                  required: "Password is required",
                  pattern: {
                    value:
                      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                    message:
                      "Password must be at least 8 characters with uppercase, lowercase, number, and special character",
                  },
                })}
                type="password"
                id="password"
                placeholder="Enter Your Password"
                className="w-full py-[1.3rem] px-[1rem] border border-[#DED2D9] rounded-[0.5rem] text-gray-700 outline-none focus:border-[#7F265B]"
              />
              {errors.password && (
                <span className="text-sm text-red-500">
                  {errors.password.message}
                </span>
              )}
            </div>

            {/* Remember Me and Terms */}
            <div className="flex items-center justify-between w-full text-sm text-[#828282]">
              <label className="flex items-center gap-2">
                <input
                  type="checkbox"
                  className="form-checkbox border border-[#DED2D9] text-blue-500 focus:ring-blue-400"
                />
                I agree to the Terms and Conditions
              </label>
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
                "Register"
              )}
            </button>
          </form>

          {/* Footer Section */}
          <p className="font-semibold text-[1.8rem] text-[#828282] text-center mt-6">
            Already have an account?{" "}
            <Link
              to="/login"
              className="font-semibold text-[1.8rem] text-[#7F265B] hover:underline"
            >
              Login
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};

export default Register;
