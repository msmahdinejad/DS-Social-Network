type PostCardProps = {
  postSrc: string;
};

const PostCard: React.FC<PostCardProps> = ({ postSrc }) => {
  return <img className="w-full h-full" src={postSrc} alt="" />;
};

export default PostCard;
