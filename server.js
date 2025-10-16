import express from 'express';
import paymentRoutes from './routes/paymentRoutes.js';
import securityRoutes from './routes/securityRoutes.js';

const app = express();
app.use(express.json());

app.get('/', (req, res) => {
  res.send('API Server is running...');
});

// 使用子路由
app.use('/api/payments', paymentRoutes);
app.use('/api/security', securityRoutes);

app.listen(5000, () => console.log('Server running on http://localhost:5000'));
