import { Link } from 'react-router-dom';

const LoginForm = ({ user, setUser, userRef, pwd, setPwd, errRef, errMsg, handleSubmit }) => {

    return (
        <section>

            <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"}>
                {errMsg}
            </p>

            <h1>Sign In</h1>

            <form onSubmit={handleSubmit}>
                <label htmlFor="username">Username</label>
                <input 
                    type="text" 
                    id="username" 
                    ref={userRef}
                    autoComplete='off'
                    onChange={(e) => setUser(e.target.value)}
                    value={user}
                    required
                />

                <label htmlFor="password">Password</label>
                <input 
                    type="password" 
                    id="password" 
                    onChange={(e) => setPwd(e.target.value)}
                    value={pwd}
                    required
                />

                <button>Sign In</button>   

            </form>

            <p>
                Don't have Account?<br/>
                <span className='line'>
                    <Link to="/register">Register</Link>
                </span>
            </p>

        </section>
    );
}

export default LoginForm;