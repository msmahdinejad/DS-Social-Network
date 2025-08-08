type CommentCardProps = {
  profileImage: string;
  username: string;
  message: string;
};

const CommentCard: React.FC<CommentCardProps> = ({
  message,
  profileImage,
  username,
}) => {
  return (
    <div className="gap-4 p-6 flex flex-col justify-start items-start w-full h-fit rounded-xl bg-white/20 backdrop-blur-md shadow-lg">
      {/* Profile Section */}
      <div className="flex justify-start items-center gap-4 w-full h-fit ">
        <img
          src={profileImage}
          alt="profileImage"
          className="w-[5rem] h-[5rem] rounded-full object-cover border-2 border-white"
        />
        <p className="font-bold text-[1.6rem] text-black">{username}</p>
      </div>

      {/* Divider */}
      <div className="w-full bg-black h-[0.01rem]"></div>

      {/* Message Section */}
      <div className="w-full h-fit text-black text-[1.6rem]">{message}</div>
    </div>
  );
};

export default CommentCard;
