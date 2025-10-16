import express from 'express';
const router = express.Router();

router.get('/', (req, res) => {
  res.json([
    { id: 1, amount: 100, status: 'paid' },
    { id: 2, amount: 50, status: 'pending' }
  ]);
});

router.post('/', (req, res) => {
  const payment = req.body;
  console.log('Payment received:', payment);
  res.status(201).json({ message: 'Payment processed', payment });
});

export default router;
