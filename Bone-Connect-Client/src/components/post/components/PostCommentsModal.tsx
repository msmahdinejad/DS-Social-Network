import React from "react";
import CommentCard from "../../common/CommentCard";

interface PostCommentsModalProps {
  isOpen: boolean;
  onClose: () => void;
}

const comments = [
  {
    id: 0,
    username: "arash",
    message: "great post",
  },
  {
    id: 1,
    username: "arash",
    message: "great post",
  },
  {
    id: 2,
    username: "arash",
    message: "great post",
  },
  {
    id: 3,
    username: "arash",
    message: "great post",
  },
  {
    id: 4,
    username: "arash",
    message: "great post",
  },
  {
    id: 5,
    username: "arash",
    message: "great post",
  },
  {
    id: 6,
    username: "arash",
    message: "great post",
  },
  {
    id: 7,
    username: "arash",
    message: "great post",
  },
  {
    id: 8,
    username: "arash",
    message: "great post",
  },
  {
    id: 9,
    username: "arash",
    message: "great post",
  },
  {
    id: 10,
    username: "arash",
    message: "great post",
  },
  {
    id: 11,
    username: "arash",
    message: "great post",
  },
];

const PostCommentsModal: React.FC<PostCommentsModalProps> = ({
  isOpen,
  onClose,
}) => {
  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
      <div className="bg-white rounded-lg w-[90%] md:w-[50%] p-6 shadow-lg">
        {/* Modal Header */}
        <div className="flex justify-between items-center border-b pb-4">
          <h2 className="text-xl font-bold">Comments</h2>
          <button
            onClick={onClose}
            className="text-gray-500 hover:text-gray-700 focus:outline-none"
            aria-label="Close modal"
          >
            ✖
          </button>
        </div>

        {/* Comments Section */}
        <div className="flex flex-col justify-start items-center gap-4 overflow-y-auto h-[40rem]">
          {comments.map((item) => (
            <CommentCard
              key={item.id}
              message={item.message}
              profileImage="../../../../public/assets/images/google.svg"
              username={item.username}
            />
          ))}
        </div>

        {/* Add Comment Section */}
        <div className="mt-6">
          <input
            type="text"
            placeholder="Add a comment..."
            className="w-full border border-gray-300 rounded-lg px-4 py-2"
          />
          <button className="mt-2 bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600">
            Post Comment
          </button>
        </div>
      </div>
    </div>
  );
};

export default PostCommentsModal;
