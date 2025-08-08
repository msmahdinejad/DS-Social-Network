export type AuthLogin = {
    username: string,
    password: string
}

export type AuthRegister = {
    username: string,
    password: string,
    firstName: string,
    lastName: string,
    email: string,
    profilePic?: string
}


export type ChangePassword = {
    oldPassword: string,
    newPassword: string,
}


export type UserPosts = {
    id: string,
    thumbnail: string,
}


export type User = {
    username: string,
    password: string,
    firstName: string,
    lastName: string,
    email: string,
    profilePic?: string,
    connections: string[],
    posts: UserPosts[],
}


export type ProfileForm = {
    username: string;
    firstName: string;
    lastName: string;
    email: string;
    profilePic: string;
};

