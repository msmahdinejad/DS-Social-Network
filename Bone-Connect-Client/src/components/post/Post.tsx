import React, { useEffect, useState } from "react";
import PostCommentsModal from "./components/PostCommentsModal";
import { useNavigate, useParams } from "react-router-dom";
import postService, { EditPost } from "../../services/postService";
import { useMutation, useQuery } from "@tanstack/react-query";
import { useForm } from "react-hook-form";

type Author = {
  profilePic: string;
  username: string;
};

type PostType = {
  author: Author;
  caption: string;
  pictures: string[];
};

const Post: React.FC = () => {
  const { postId } = useParams();
  const [liked, setLiked] = useState(false);
  const [isModalOpen, setModalOpen] = useState(false);
  const [isDeleteModalOpen, setDeleteModalOpen] = useState(false);
  const [isEditModalOpen, setEditModalOpen] = useState(false);
  const navigate = useNavigate();

  const handleLike = () => setLiked(!liked);
  const handleComment = () => setModalOpen(true);

  const { data: post, refetch } = useQuery<PostType>({
    queryKey: ["post", postId],
    queryFn: () => postService.getPostById(postId as string),
  });

  const { mutate: mutateDelete } = useMutation({
    mutationFn: () => postService.deletePostById(postId as string),
    mutationKey: ["deletePost"],
    onSuccess: () => {
      setDeleteModalOpen(false);
      navigate("/profile");
    },
  });

  const { mutate: mutateEdit } = useMutation({
    mutationFn: (data: EditPost) => postService.editPostById(data),
    mutationKey: ["editPost"],
    onSuccess: () => {
      setEditModalOpen(false);
      refetch();
    },
  });

  const { register, handleSubmit, reset } = useForm({
    defaultValues: {
      caption: post?.caption || "",
      pictures: post?.pictures || [],
    },
  });

  const onSubmit = (data: { caption: string; pictures: string[] }) => {
    const formatted: EditPost = {
      postId: postId as string,
      caption: data.caption,
      pictures: [...data.pictures],
    };
    mutateEdit(formatted);
    reset();
  };

  return (
    <>
      <div className="w-full h-full flex justify-center items-center">
        <div className="w-[90%] md:w-[50%] rounded-xl shadow-lg bg-glassy">
          {/* Header */}
          <div className="flex items-center gap-5 p-6 bg-white rounded-t-xl border-b border-gray-300">
            <img
              className="w-16 h-16 md:w-24 md:h-24 rounded-full border-4 border-white"
              src={post?.author.profilePic}
              alt={`${post?.author.username}'s profile`}
            />
            <span className="font-bold text-[1.6rem] text-black">
              {post?.author.username}
            </span>
          </div>

          {/* Content */}
          <div className="bg-gray-100 flex justify-center items-center w-full h-[50rem] p-6">
            <p className="text-gray-800 text-base md:text-lg">
              {post?.caption}
            </p>
          </div>

          {/* Footer */}
          <div className="rounded-b-xl bg-white flex items-center justify-between px-6 py-4 border-t border-gray-300">
            <div className="flex items-center gap-4">
              {/* Like Button */}
              <button
                onClick={handleLike}
                className="flex items-center justify-center w-[5rem] h-[5rem] rounded-full"
              >
                <img
                  src={
                    liked
                      ? "../../../public/assets/images/yesLike.svg"
                      : "../../../public/assets/images/noLike.svg"
                  }
                  alt="Like"
                  className="w-full h-full"
                />
              </button>

              {/* Comment Button */}
              <button
                onClick={handleComment}
                className="flex items-center justify-center w-[5rem] h-[5rem] rounded-full"
              >
                <img
                  src="../../../public/assets/images/comment.svg"
                  alt="Comment"
                  className="text-white w-full h-full"
                />
              </button>
            </div>

            {/* Delete Button */}
            <button
              onClick={() => setDeleteModalOpen(true)}
              className="flex items-center justify-center w-[5rem] h-[5rem] rounded-full"
            >
              <img
                src="../../../public/assets/images/deleteAcc.svg"
                alt="Delete"
                className="w-full h-full"
              />
            </button>

            <button
              onClick={() => setEditModalOpen(true)}
              className="flex items-center justify-center w-[5rem] h-[5rem] rounded-full"
            >
              <img
                src="../../../public/assets/images/setting.svg"
                alt="Edit"
                className="w-full h-full"
              />
            </button>
          </div>
        </div>
      </div>

      {/* Comments Modal */}
      <PostCommentsModal
        isOpen={isModalOpen}
        onClose={() => setModalOpen(false)}
      />

      {/* Delete Confirmation Modal */}
      {isDeleteModalOpen && (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-6 rounded-xl shadow-lg text-center">
            <p className="text-lg font-semibold mb-4">
              Are you sure you want to delete this post?
            </p>
            <div className="flex justify-center gap-4">
              <button
                onClick={() => mutateDelete()}
                className="bg-red-500 text-white px-4 py-2 rounded-lg"
              >
                Yes, Delete
              </button>
              <button
                onClick={() => setDeleteModalOpen(false)}
                className="bg-gray-300 px-4 py-2 rounded-lg"
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Edit Post Modal */}
      {isEditModalOpen && (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-6 rounded-xl shadow-lg text-center">
            <h2 className="text-lg font-semibold mb-4">Edit Post</h2>
            <form onSubmit={handleSubmit(onSubmit)}>
              <input
                {...register("caption")}
                className="border p-2 w-full rounded mb-3"
                placeholder="Caption"
              />
              <input
                {...register("pictures")}
                className="border p-2 w-full rounded mb-3"
                placeholder="Pictures (comma-separated)"
              />
              <div className="flex justify-center gap-4">
                <button
                  type="submit"
                  className="bg-blue-500 text-white px-4 py-2 rounded-lg"
                >
                  Save
                </button>
                <button
                  type="button"
                  onClick={() => setEditModalOpen(false)}
                  className="bg-gray-300 px-4 py-2 rounded-lg"
                >
                  Cancel
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </>
  );
};

export default Post;
