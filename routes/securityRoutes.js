import express from 'express';
const router = express.Router();

// 登录接口
router.post('/login', (req, res) => {
  const { username, password } = req.body;
  if (username === 'admin' && password === '1234') {
    res.json({ token: 'fake-jwt-token', message: 'Login successful' });
  } else {
    res.status(401).json({ message: 'Invalid credentials' });
  }
});

// 登出接口
router.post('/logout', (req, res) => {
  res.json({ message: 'Logged out successfully' });
});

export default router;
