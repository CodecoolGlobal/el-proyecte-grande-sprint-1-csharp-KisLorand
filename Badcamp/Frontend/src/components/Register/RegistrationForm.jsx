import { Link } from 'react-router-dom';

const RegistrationForm = ( { newUserName, setNewUserName, fullName, setFullName, birthDate, setBirthDate, 
    pwd1, setPwd1, pwd2, setPwd2, errMsg, handleSubmit }) => {

    return (
        <section>

        <p className={errMsg ? "errmsg" : "offscreen"}>
            {errMsg}
        </p>

        <h1>Register</h1>

        <form onSubmit={handleSubmit}>
            <label htmlFor="username">*Username</label>
            <input 
                type="text" 
                id="username" 
                autoComplete='off'
                onChange={(e) => setNewUserName(e.target.value)}
                value={newUserName}
                required
            />

            <label htmlFor="fullname">*FullName</label>
            <input 
                type="text" 
                id="fullname" 
                onChange={(e) => setFullName(e.target.value)}
                value={fullName}
                required
            />

            <label htmlFor="birthdate">*Date of birth</label>
            <input 
                type="date" 
                id="birthdate" 
                onChange={(e) => setBirthDate(e.target.value)}
                value={birthDate}
                required
            />

            <label htmlFor="password1">*Password</label>
            <input 
                type="password" 
                id="password1" 
                onChange={(e) => setPwd1(e.target.value)}
                value={pwd1}
                required
            />

            <label htmlFor="password2">*Confirm Password</label>
            <input 
                type="password" 
                id="password2" 
                onChange={(e) => setPwd2(e.target.value)}
                value={pwd2}
                required
            />

            <button>Register</button>   

        </form>       

        <p>
            Already have Account?<br/>
            <span className='line'>
                <Link to="/login">Sign In</Link>
            </span>
        </p>

        </section>
    );
}

export default RegistrationForm;