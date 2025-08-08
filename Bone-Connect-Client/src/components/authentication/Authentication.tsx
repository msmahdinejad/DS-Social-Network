import Login from "./components/Login";
import Register from "./components/Register";
import { useLocation } from "react-router-dom";
const Authentication: React.FC = () => {
  const location = useLocation();

  return (
    <div className="h-screen min-h-screen  w-full p-5">
      <div className="flex rounded-2xl w-full h-full ">
        <div className="relative rounded-l-2xl flex-1 flex justify-center items-center bg-[#FFE6C9]">
          <img
            className="w-64 absolute top-0  left-0"
            src="../../../public/assets/images/moon.svg"
            alt=""
          />

          <div className="relative">
            <img src="../../../public/assets/images/centerCircle.svg" alt="" />
            <img
              className="absolute top-[15rem] right-[-5rem]"
              src="../../../public/assets/images/message.svg"
              alt=""
            />
            <img
              className="absolute top-[17rem] left-[-5rem] transform rotate-180"
              src="../../../public/assets/images/message.svg"
              alt=""
            />

            <img
              className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 z-10"
              src="../../../public/assets/images/skelete.svg"
              alt=""
            />
          </div>
        </div>
        <div className="flex-1 bg-red-300">
          {location.pathname === "/login" ? (
            <Login />
          ) : location.pathname === "/register" ? (
            <Register />
          ) : null}
        </div>
      </div>
    </div>
  );
};

export default Authentication;
