import React from "react";

type ProfileCardProps = {
  image: string;
  userName: string;
  onFollow?: () => void;
  onViewProfile?: () => void;
  isNeedConnect: boolean;
  isNeedView: boolean;
};

const ProfileCard: React.FC<ProfileCardProps> = ({
  image,
  userName,
  onFollow,
  onViewProfile,
  isNeedConnect,
  isNeedView,
}) => {
  return (
    <div className="w-full p-4 bg-white border rounded-lg shadow-md">
      {/* Profile Image */}
      <div className="flex justify-center">
        <img
          src={image}
          alt={userName}
          className="w-24 h-24 rounded-full object-cover"
        />
      </div>

      {/* Profile Name */}
      <div className="text-center mt-4">
        <h3 className="text-lg font-semibold">{userName}</h3>
      </div>

      {/* Buttons */}
      <div className="mt-4 flex justify-center space-x-2">
        {isNeedView ? (
          <button
            onClick={onViewProfile}
            className="text-[1.6rem] px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
          >
            View profile
          </button>
        ) : null}
        {isNeedConnect ? (
          <button
            onClick={onFollow}
            className="text-[1.6rem] px-4 py-2 bg-gray-200 text-gray-800 rounded hover:bg-gray-300"
          >
            Connect
          </button>
        ) : null}
      </div>
    </div>
  );
};

export default ProfileCard;
