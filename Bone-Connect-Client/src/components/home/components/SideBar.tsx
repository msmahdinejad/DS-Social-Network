import { useState } from "react";

const Sidebar = () => {
  const [searchQuery, setSearchQuery] = useState("");
  const users = ["John Doe", "Jane Smith", "Alice Johnson", "Bob Brown"];
  const filteredUsers = users.filter((user) =>
    user.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="bg-gray-100 flex flex-col items-center p-4 basis-1/4 h-full">
      {/* Search Box */}
      <div className="w-full mb-4">
        <input
          type="text"
          placeholder="Search users..."
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          className="w-full p-2 border rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
      </div>

      {/* User List */}
      <div className="w-full flex flex-col gap-2 overflow-y-auto">
        {filteredUsers.length > 0 ? (
          filteredUsers.map((user, index) => (
            <div
              key={index}
              className="p-2 bg-white border rounded hover:bg-gray-50 transition"
            >
              {user}
            </div>
          ))
        ) : (
          <div className="text-gray-500">No users found</div>
        )}
      </div>
    </div>
  );
};

export default Sidebar;
