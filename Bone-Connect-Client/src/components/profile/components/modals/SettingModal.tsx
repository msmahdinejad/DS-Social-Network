import React from "react";

type SettingModalProps = {
  isOpen: boolean;
  onClose: () => void;
};

const SettingModal: React.FC<SettingModalProps> = ({ isOpen, onClose }) => {
  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
      <div className="bg-white w-full max-w-md rounded-lg shadow-lg p-6 relative">
        {/* Close Button */}
        <button
          onClick={onClose}
          className="absolute top-4 right-4 text-gray-500 hover:text-gray-800"
        >
          ✖
        </button>

        {/* Modal Content */}
        <h2 className="text-xl font-semibold mb-4">Settings</h2>
        <form className="space-y-4">
          {/* Example Input */}
          <div>
            <label
              className="block text-sm font-medium mb-1"
              htmlFor="username"
            >
              Username
            </label>
            <input
              type="text"
              id="username"
              className="w-full p-2 border rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Enter your username"
            />
          </div>

          {/* Example Toggle Switch */}
          <div className="flex items-center justify-between">
            <span className="text-sm font-medium">Enable Notifications</span>
            <input type="checkbox" className="toggle-checkbox" />
          </div>

          {/* Save Button */}
          <button
            type="submit"
            className="w-full bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600"
          >
            Save Changes
          </button>
        </form>
      </div>
    </div>
  );
};

export default SettingModal;
