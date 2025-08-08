import { Link, useNavigate, useParams } from "react-router-dom";
import PostCard from "./components/PostCard";
import { useMutation, useQuery } from "@tanstack/react-query";
import userService from "../../services/userService";
import { User } from "../../types/types";
import { useState } from "react";
import ConnectionModal from "./components/modals/Connections";

const ConnectionProfile = () => {
  const { username } = useParams();
  const [isRemoveModalOpen, setIsRemoveModalOpen] = useState(false);
  const navigate = useNavigate();
  const [isConnectionModalOpen, setIsConnectionModalOpen] = useState(false);

  const handleCloseSConnections = () => {
    setIsConnectionModalOpen(false);
  };

  const { data: userData, refetch } = useQuery<User>({
    queryKey: ["getUserById"],
    queryFn: () => userService.getUserById(username as string),
  });

  const { mutate: removeConnection } = useMutation({
    mutationKey: ["removeConnection"],
    mutationFn: () => userService.removeConnection(username as string),
    onSuccess: () => {
      setIsRemoveModalOpen(false);
      refetch();
      navigate("/profile");
    },
  });

  return (
    <div className="p-6 w-full h-full">
      {/* Header Section */}
      <div className="flex items-center justify-between border-b border-black pb-4">
        <div className="flex items-center justify-center gap-5">
          {/* Profile Image */}
          <img
            className="w-[7rem] h-[7rem] rounded-full"
            src={userData?.profilePic}
            alt="Profile"
          />
          <p className="font-bold text-[1.6rem]">{userData?.username}</p>

          {/* Connections and Posts */}
          <div className="flex justify-center items-center gap-8 text-[1.6rem] bg-white bg-opacity-20 backdrop-blur-md p-4 rounded-xl border border-white border-opacity-30 shadow-lg">
            <button
              onClick={() => {
                setIsConnectionModalOpen(true);
              }}
              className="flex items-center gap-2"
            >
              Connections:
              <span className="font-semibold text-black">
                {userData?.connections.length}
              </span>
            </button>
            <p className="flex items-center gap-2">
              Posts:
              <span className="font-semibold text-black">
                {userData?.posts.length}
              </span>
            </p>
          </div>
        </div>
        {/* Delete Button */}
        <div className="flex justify-center items-center gap-8">
          <button
            onClick={() => setIsRemoveModalOpen(true)}
            className="flex-col w-[7rem] p-2 h-fit rounded-2xl bg-white bg-opacity-30 backdrop-blur-md border border-white border-opacity-20 shadow-xl flex items-center justify-center"
          >
            <img
              className="w-full h-full"
              src="../../../public/assets/images/deleteAcc.svg"
              alt="Delete Account"
            />
            <p className="text-[1.2rem]">Remove</p>
          </button>
        </div>
      </div>
      {/* Posts Grid */}
      <div className="h-[60rem] overflow-y-auto">
        <div className="grid grid-cols-3 gap-4">
          {userData?.posts.map((item, index) => (
            <Link key={index} to={`/post/${item.id}`}>
              <PostCard postSrc={item.thumbnail} />
            </Link>
          ))}
        </div>
      </div>
      {/* Confirmation Modal */}
      {isRemoveModalOpen && (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-6 rounded-lg shadow-lg text-center">
            <p className="text-xl font-semibold mb-4">
              Are you sure you want to remove this connection?
            </p>
            <div className="flex justify-center gap-4">
              <button
                onClick={() => setIsRemoveModalOpen(false)}
                className="px-4 py-2 bg-gray-300 rounded-md hover:bg-gray-400"
              >
                Cancel
              </button>
              <button
                onClick={() => removeConnection()}
                className="px-4 py-2 bg-red-500 text-white rounded-md hover:bg-red-600"
              >
                Remove
              </button>
            </div>
          </div>
        </div>
      )}

      <ConnectionModal
        isOpen={isConnectionModalOpen}
        onClose={handleCloseSConnections}
        users={userData?.connections}
      />
    </div>
  );
};

export default ConnectionProfile;
