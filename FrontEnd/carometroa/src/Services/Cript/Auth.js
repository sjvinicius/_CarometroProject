export default function tokenDecode(token) {
    
    token = localStorage.getItem('tokenUserUp').split('.')[1];

    return JSON.parse(window.atob(token));

}