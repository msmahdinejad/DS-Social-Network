import React from "react";

type NotificationCardProps = {
  username: string;
  message: string;
  isReq: boolean;
};

const NotificationCard: React.FC<NotificationCardProps> = ({
  isReq,
  message,
  username,
}) => {
  return (
    <div className="w-full bg-white bg-opacity-40 backdrop-blur-lg rounded-lg p-4 shadow-lg flex flex-col gap-5">
      <div className="flex justify-between items-center">
        <h3 className="font-semibold text-[1.6rem] text-black">{username}</h3>
        <span
          className={`text-[1.6rem] ${
            isReq ? "text-blue-400" : "text-green-400"
          }`}
        >
          {isReq ? "Follow Request" : "Notification"}
        </span>
      </div>
      <p className="text-black text-[1.6rem]">{`${username} ==> ${message}`}</p>

      {/* Conditionally render Accept and Deny buttons if isReq is true */}
      {isReq && (
        <div className="flex gap-4 mt-4">
          <button className="bg-blue-500 text-white text-lg font-semibold px-4 py-2 rounded-md hover:bg-blue-600 transition-colors">
            Accept
          </button>
          <button className="bg-red-500 text-white text-lg font-semibold px-4 py-2 rounded-md hover:bg-red-600 transition-colors">
            Deny
          </button>
        </div>
      )}
    </div>
  );
};

export default NotificationCard;
