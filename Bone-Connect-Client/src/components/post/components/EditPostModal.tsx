import React from "react";
import { useForm } from "react-hook-form";

interface EditPostModalProps {
  isOpen: boolean;
  onClose: () => void;
  defaultCaption: string;
  defaultPictures: string[];
  onSave: (data: { caption: string; pictures: string[] }) => void;
}

const EditPostModal: React.FC<EditPostModalProps> = ({
  isOpen,
  onClose,
  defaultCaption,
  defaultPictures,
  onSave,
}) => {
  const { register, handleSubmit, reset } = useForm({
    defaultValues: {
      caption: defaultCaption,
      pictures: defaultPictures,
    },
  });

  const onSubmit = (data: { caption: string; pictures: string[] }) => {
    onSave(data);
    onClose();
    reset();
  };

  if (!isOpen) return null;

  return (
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
              onClick={onClose}
              className="bg-gray-300 px-4 py-2 rounded-lg"
            >
              Cancel
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default EditPostModal;
