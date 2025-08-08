import { useState } from "react";
import SettingModal from "./components/modals/SettingModal";
import SuggestionModal from "./components/modals/SuggestionModal";
import PostCard from "./components/PostCard";
import { Link, useNavigate } from "react-router-dom";
import userService from "../../services/userService";
import useAuthStore from "../../stores/useAuthStore";
import useGetUser from "../../hooks/useGetUser";
import ConnectionModal from "./components/modals/Connections";

const Profile = () => {
  const { userInfo, refetch } = useGetUser();

  const navigate = useNavigate();
  const { logout } = useAuthStore();

  const [isSettingModalOpen, setIsSettingModalOpen] = useState(false);
  const [isSuggestionModalOpen, setIsSuggestionModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [isConnectionModalOpen, setIsConnectionModalOpen] = useState(false);

  const handleCloseSettings = () => {
    setIsSettingModalOpen(false);
  };

  const handleOpenSuggestions = () => {
    setIsSuggestionModalOpen(true);
  };

  const handleCloseSuggestions = () => {
    setIsSuggestionModalOpen(false);
  };

  const handleCloseSConnections = () => {
    setIsConnectionModalOpen(false);
  };

  return (
    <div className="p-6 w-full h-full">
      {/* Header Section */}
      <div className="flex items-center justify-between border-b border-black pb-4">
        <div className="flex items-center justify-center gap-5">
          {/* Profile Image */}
          <img
            className="w-[7rem] h-[7rem] rounded-full"
            src={userInfo?.profilePic}
            alt={`${userInfo?.username} profile picture`}
          />
          <p className="font-bold text-[1.6rem]">{userInfo?.username}</p>
          {/* Followers and Following */}
          <div className="flex justify-center items-center gap-8 text-[1.6rem] bg-white bg-opacity-20 backdrop-blur-md p-4 rounded-xl border border-white border-opacity-30 shadow-lg">
            <button
              onClick={() => {
                setIsConnectionModalOpen(true);
              }}
              className="flex items-center gap-2"
            >
              Connections:
              <span className="font-semibold text-black">
                {userInfo?.connections.length}
              </span>
            </button>
            <p className="flex items-center gap-2">
              Posts:
              <span className="font-semibold text-black">
                {userInfo?.posts.length}
              </span>
            </p>
          </div>
        </div>
        {/* Buttons */}
        <div className="flex justify-center items-center gap-8">
          <Link
            to="/setting"
            className=" flex-col w-[7rem] p-2 h-fit rounded-2xl bg-white bg-opacity-30 backdrop-blur-md border border-white border-opacity-20 shadow-xl flex items-center justify-center"
          >
            <img
              className="w-full h-full"
              src="../../../public/assets/images/setting.svg"
              alt="Settings"
            />
            <p className="text-[1.2rem]">Setting</p>
          </Link>
          <button
            onClick={handleOpenSuggestions}
            className="flex-col  w-[7rem] p-3 h-fit rounded-2xl bg-white bg-opacity-30 backdrop-blur-md border border-white border-opacity-20 shadow-xl flex items-center justify-center"
          >
            <img
              className="w-full h-full"
              src="../../../public/assets/images/suggestion.svg"
              alt="Suggestions"
            />
            <p className="text-[1.2rem]">Suggestion</p>
          </button>
          <button
            onClick={() => {
              setIsDeleteModalOpen(true);
            }}
            className="flex-col w-[7rem] p-2 h-fit rounded-2xl bg-white bg-opacity-30 backdrop-blur-md border border-white border-opacity-20 shadow-xl flex items-center justify-center"
          >
            <img
              className="w-full h-full"
              src="../../../public/assets/images/deleteAcc.svg"
              alt="Delete Account"
            />
            <p className="text-[1.2rem]">Delete</p>
          </button>
        </div>
      </div>

      {/* Comments Section */}
      <div className="h-[60rem] overflow-y-auto">
        <div className="grid grid-cols-3 gap-4 ">
          {userInfo?.posts.map((item, index) => (
            <Link key={index} to={`/post/${item.id}`}>
              <PostCard postSrc={item.thumbnail} />
            </Link>
          ))}
        </div>
      </div>

      {isDeleteModalOpen && (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-6 rounded-lg">
            <p className="text-lg">
              Are you sure you want to delete your account?
            </p>
            <div className="flex justify-end gap-4 mt-4">
              <button
                onClick={() => setIsDeleteModalOpen(false)}
                className="px-4 py-2 bg-gray-300 rounded"
              >
                Cancel
              </button>
              <button
                onClick={() => {
                  userService.deleteUser();
                  logout();
                  localStorage.clear();
                  navigate("/login");
                }}
                className="px-4 py-2 bg-red-600 text-white rounded"
              >
                Delete
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Modals */}
      <SettingModal isOpen={isSettingModalOpen} onClose={handleCloseSettings} />
      <SuggestionModal
        isOpen={isSuggestionModalOpen}
        onClose={handleCloseSuggestions}
      />
      <ConnectionModal
        users={userInfo?.connections}
        isOpen={isConnectionModalOpen}
        onClose={handleCloseSConnections}
      />
    </div>
  );
};

export default Profile;
