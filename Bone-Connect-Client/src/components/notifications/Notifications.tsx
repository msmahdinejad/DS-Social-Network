import NotificationCard from "./components/NotificationCard";

const notifs = [
  {
    username: "Arash 1",
    message: "accepted your follow request",
    isReq: false,
  },
  {
    username: "Arash 2",
    message: "sent you follow request",
    isReq: true,
  },
  {
    username: "Arash 3",
    message: "liked your post",
    isReq: false,
  },
  {
    username: "Arash 4",
    message: "commented on your post ",
    isReq: false,
  },
  {
    username: "Arash 1",
    message: "accepted your follow request",
    isReq: false,
  },
  {
    username: "Arash 2",
    message: "sent you follow request",
    isReq: true,
  },
  {
    username: "Arash 3",
    message: "liked your post",
    isReq: false,
  },
  {
    username: "Arash 4",
    message: "commented on your post ",
    isReq: false,
  },
];

const Notifications = () => {
  return (
    <div className=" flex flex-col justify-start items-start px-6 w-full h-full overflow-y-auto ">
      <h1 className="text-[1.8rem]">Notifications : </h1>
      <div className="w-full h-full flex flex-col justify-start items-start gap-6">
        {notifs.map((item, index) => (
          <NotificationCard
            isReq={item.isReq}
            message={item.message}
            username={item.username}
            key={index}
          />
        ))}
      </div>
    </div>
  );
};

export default Notifications;
