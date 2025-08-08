import React from "react";
import ProfileCard from "../ProfileCard";
import { useQuery } from "@tanstack/react-query";
import suggestionService from "../../../../services/suggestionService";
import userService from "../../../../services/userService";
import useGetUser from "../../../../hooks/useGetUser";
import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
type SuggestionModalProps = {
  isOpen: boolean;
  onClose: () => void;
};

type SuggestUser = {
  username: string;
  profilePic: string;
};

const SuggestionModal: React.FC<SuggestionModalProps> = ({
  isOpen,
  onClose,
}) => {
  const { refetch } = useGetUser();
  const navigate = useNavigate();
  const { data: suggestions } = useQuery<SuggestUser[]>({
    queryKey: ["getSuggestions"],
    queryFn: () => suggestionService.getSuggestions(),
  });

  const { mutate: connectUser } = useMutation({
    mutationFn: (id: string) => userService.addConnection(id),
    mutationKey: ["connectToUser"],
    onSuccess: () => {
      refetch();
    },
  });

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
      <div className="bg-white p-4 rounded w-1/3 h-[90%]">
        {/* Header */}
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-bold">Suggestions</h2>
          <button
            onClick={onClose}
            className="text-gray-500 hover:text-gray-800"
          >
            ✕
          </button>
        </div>

        {/* Suggestions List */}
        <div className="flex flex-col justify-start items-center gap-4 w-full h-[90%] overflow-y-auto">
          {suggestions?.map((user, index) => (
            <ProfileCard
              key={index}
              image={user.profilePic}
              userName={user.username}
              onFollow={() => {
                connectUser(user.username);
                refetch();
                navigate("/");
              }}
              isNeedConnect={true}
              isNeedView={false}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default SuggestionModal;
