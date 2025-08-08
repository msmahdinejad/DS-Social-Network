import { create } from 'zustand';


interface AuthState {
    isAuth: boolean;
    login: () => void;
    logout: () => void;
}

const useAuthStore = create<AuthState>((set) => ({
    isAuth: JSON.parse(localStorage.getItem('isAuth') || 'false'),

    login: () => {
        localStorage.setItem('isAuth', JSON.stringify(true));
        set({ isAuth: true });
    },

    logout: () => {
        localStorage.setItem('isAuth', JSON.stringify(false));
        set({ isAuth: false });
    }
}));

export default useAuthStore;
