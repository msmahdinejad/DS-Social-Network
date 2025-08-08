import { RouterProvider } from "react-router-dom";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import useRoutes from "./router/routes";
import { useEffect } from "react";
import userService from "./services/userService";
import postService from "./services/postService";

const App = () => {
  useEffect(() => {
    // postService.createPost({ caption: "bia bia", pictures: ["1", "2"] });
    userService.getUserByAuth();
  }, []);
  const queryClient = new QueryClient();
  const { routes } = useRoutes();
  return (
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={routes} />
    </QueryClientProvider>
  );
};

export default App;
