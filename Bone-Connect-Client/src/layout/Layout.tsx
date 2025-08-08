import { Outlet, useLocation } from "react-router-dom";
import Panel from "./components/Panel";
import Profile from "../components/profile/Profile";

const Layout = () => {
  const { pathname } = useLocation();

  return (
    <div className="bg-slate-400 p-6  flex justify-start items-center h-screen">
      <div className=" w-[20%] h-full flex justify-center items-start pt-10">
        <Panel />
      </div>
      <div className="  w-[80%] h-full pt-10">
        {pathname === "/" ? <Profile /> : null}
        <Outlet></Outlet>
      </div>
    </div>
  );
};

export default Layout;
