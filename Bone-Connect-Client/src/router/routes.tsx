import { createBrowserRouter, Navigate } from "react-router-dom";
import AuthenticationPage from "../pages/authenticationPage/AuthenticationPage";
import Layout from "../layout/Layout";
import NotificationsPage from "../pages/notificationsPage/NotificationsPage";
import ProfilePage from "../pages/profilePage/ProfilePage";
import SettingPage from "../pages/settingPage/SettingPage";
import useAuthStore from "../stores/useAuthStore";

import ConnectionProfile from "../components/profile/ConnectionProfile";
import Post from "../components/post/Post";
import ExplorePage from "../pages/explorePage/ExplorePage";
const useRoutes = () => {
  const { isAuth } = useAuthStore();
  const routes = createBrowserRouter([
    {
      path: "/",
      element: isAuth ? <Layout /> : <Navigate to="/login" />,
      children: [
        {
          path: "/profile",
          element: <ProfilePage />,
        },
        {
          path: "/notifications",
          element: <NotificationsPage />,
        },
        {
          path: "/saved",
          element: <h1>saved</h1>,
        },
        {
          path: "/setting",
          element: <SettingPage />,
        },
        {
          path: "/explore",
          element: <ExplorePage />,
        },
        {
          path: "/profile/:username",
          element: <ConnectionProfile />,
        },
        {
          path: "/post/:postId",
          element: <Post />,
        },
      ],
    },
    {
      path: "/login",
      element: <AuthenticationPage />,
    },
    {
      path: "/register",
      element: <AuthenticationPage />,
    },
  ]);

  return {
    routes,
  };
};

export default useRoutes;
