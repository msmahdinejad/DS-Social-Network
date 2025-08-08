import React from "react";
import ProfileCard from "../ProfileCard";
import type { User } from "../../../../types/types";
import { useNavigate } from "react-router-dom";

type SuggestionModalProps = {
  isOpen: boolean;
  onClose: () => void;
  users: User[];
};

const ConnectionModal: React.FC<SuggestionModalProps> = ({
  isOpen,
  onClose,
  users,
}) => {
  const navigate = useNavigate();
  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
      <div className="bg-white p-4 rounded w-1/3 h-[90%]">
        {/* Header */}
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-bold">Connections</h2>
          <button
            onClick={onClose}
            className="text-gray-500 hover:text-gray-800"
          >
            ✕
          </button>
        </div>

        {/* Suggestions List */}
        <div className="flex flex-col justify-start items-center gap-4 w-full h-[90%] overflow-y-auto">
          {users.map((user, index) => (
            <ProfileCard
              key={index}
              image={user.profilePic as string}
              userName={user.username}
              onViewProfile={() => {
                console.log(`/profile/${user.username}`);
                navigate(`/profile/${user.username}`);
              }}
              isNeedConnect={false}
              isNeedView={true}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default ConnectionModal;
