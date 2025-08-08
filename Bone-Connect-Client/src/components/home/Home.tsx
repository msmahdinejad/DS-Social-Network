import Profile from "../profile/Profile";
import Sidebar from "./components/SideBar";
const Home = () => {
  return (
    <div className="min-h-screen flex">
      {/* Sidebar Section */}
      <div className="bg-gray-100 flex flex-col items-center p-4 basis-1/4">
        <Sidebar />
        {/* Add sidebar content here */}
      </div>

      {/* Main Content Section */}
      <div className="flex-1 p-6 bg-white shadow-lg">
        <Profile />
      </div>
    </div>
  );
};

export default Home;
