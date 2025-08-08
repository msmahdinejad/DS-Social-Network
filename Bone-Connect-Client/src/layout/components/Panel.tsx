import { Link } from "react-router-dom";
import useAuthStore from "../../stores/useAuthStore";
import useGetUser from "../../hooks/useGetUser";

const panelItems = [
  {
    icon: "/assets/images/ic-profile.svg",
    route: "/profile",
    itemName: "Profile",
  },
  {
    icon: "/assets/images/ic-notifications.svg",
    route: "/notifications",
    itemName: "Notifications",
  },
  {
    icon: "/assets/images/ic-saved.svg",
    route: "/saved",
    itemName: "Saved",
  },
  {
    icon: "/assets/images/ic-setting.svg",
    route: "/setting",
    itemName: "Setting",
  },
  {
    icon: "/assets/images/ic-explore.svg",
    route: "/explore",
    itemName: "Explore",
  },
  {
    icon: "/assets/images/logout.svg",
    route: "/login",
    itemName: "Logout",
  },
];

const Panel = () => {
  const { logout } = useAuthStore();
  const { userInfo } = useGetUser();

  return (
    <div className="relative w-full h-[41rem] rounded-2xl bg-slate-900">
      {/* Header Section */}
      <div className="bg-black w-full h-[9rem] rounded-t-2xl"></div>
      <img
        className="absolute top-[9rem] border-solid border-white border-[0.2rem] left-1/2 transform -translate-x-1/2 -translate-y-1/2 rounded-full h-[10rem] w-[10rem]"
        src={userInfo?.profilePic}
        alt="User Avatar"
      />

      {/* User Name */}
      <div className="flex flex-col justify-start items-center pt-[5rem] w-full h-full">
        <p className=" w-full text-center text-white text-[1.6rem] font-bold py-2">
          {userInfo?.username}
        </p>

        {/* Panel Items Section */}
        <div className="grid grid-cols-2 gap-4 p-4 w-full">
          {panelItems.map((item, index) => (
            <Link
              onClick={() => {
                if (item.itemName === "Logout") {
                  logout();
                  localStorage.clear();
                } else return null;
              }}
              key={index}
              to={item.route}
              className="flex flex-col items-center justify-center bg-gray-800 text-white p-4 rounded-xl hover:bg-gray-700 transition"
            >
              <img
                src={item.icon}
                alt={item.itemName}
                className="w-10 h-10 mb-2"
              />
              <span className="text-[1.1rem]">{item.itemName}</span>
            </Link>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Panel;
