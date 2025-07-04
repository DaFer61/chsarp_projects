using System.Diagnostics.Eventing.Reader;

namespace blackjack
{
    public partial class Form1 : Form
    {
        string[] cards_pick = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        string[] cards_korr = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        string[] cards_tref = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        string[] cards_karo = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        Random deck = new Random();
        Random num = new Random();
        int sum = 0;
        int banksum = 0;
        int yesno = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            label4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int card_type = deck.Next(1, 5);
            int card_num;
            switch (card_type)
            {
                case 1:
                    card_num = num.Next(0, cards_pick.Length);
                    listBox1.Items.Add($"Pick {cards_pick[card_num]}");

                    if ((cards_pick[card_num] != "J") & (cards_pick[card_num] != "Q") & (cards_pick[card_num] != "K") & (cards_pick[card_num] != "A"))
                    {
                        sum += Int32.Parse(cards_pick[card_num]);
                    }
                    else if (cards_pick[card_num] == "A")
                    {
                        if (sum < 11)
                        {
                            sum += 11;
                        }
                        else
                        {
                            ++sum;
                        }
                    }
                    else
                    {
                        sum += 10;
                    }
                    if (sum > 21)
                    {
                        label1.Text = "Túlmentél";
                        label4.Text = "Vesztettél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else if (sum == 21)
                    {
                        label1.Text = "BLACKJACK";
                        label4.Text = "Nyertél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else
                    {
                        cards_pick = cards_pick.Where((source, index) => index != card_num).ToArray();
                        label1.Text = $"Összeg: {sum}";
                    }
                    break;
                case 2:
                    card_num = num.Next(0, cards_korr.Length);
                    listBox1.Items.Add($"Kör {cards_korr[card_num]}");

                    if ((cards_korr[card_num] != "J") & (cards_korr[card_num] != "Q") & (cards_korr[card_num] != "K") & (cards_korr[card_num] != "A"))
                    {
                        sum += Int32.Parse(cards_korr[card_num]);
                    }
                    else if (cards_korr[card_num] == "A")
                    {
                        if (sum < 11)
                        {
                            sum += 11;
                        }
                        else
                        {
                            ++sum;
                        }
                    }
                    else
                    {
                        sum += 10;
                    }
                    if (sum > 21)
                    {
                        label1.Text = "Túlmentél";
                        label4.Text = "Vesztettél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else if (sum == 21)
                    {
                        label1.Text = "BLACKJACK";
                        label4.Text = "Nyertél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else
                    {
                        cards_korr = cards_korr.Where((source, index) => index != card_num).ToArray();
                        label1.Text = $"Összeg: {sum}";
                    }
                    break;
                case 3:
                    card_num = num.Next(0, cards_tref.Length);
                    listBox1.Items.Add($"Treff {cards_tref[card_num]}");

                    if ((cards_tref[card_num] != "J") & (cards_tref[card_num] != "Q") & (cards_tref[card_num] != "K") & (cards_tref[card_num] != "A"))
                    {
                        sum += Int32.Parse(cards_tref[card_num]);
                    }
                    else if (cards_tref[card_num] == "A")
                    {
                        if (sum < 11)
                        {
                            sum += 11;
                        }
                        else
                        {
                            ++sum;
                        }
                    }
                    else
                    {
                        sum += 10;
                    }
                    if (sum > 21)
                    {
                        label1.Text = "Túlmentél";
                        label4.Text = "Vesztettél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else if (sum == 21)
                    {
                        label1.Text = "BLACKJACK";
                        label4.Text = "Nyertél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else
                    {
                        cards_tref = cards_tref.Where((source, index) => index != card_num).ToArray();
                        label1.Text = $"Összeg: {sum}";
                    }
                    break;
                case 4:
                    card_num = num.Next(0, cards_karo.Length);
                    listBox1.Items.Add($"Káró {cards_karo[card_num]}");

                    if ((cards_karo[card_num] != "J") & (cards_karo[card_num] != "Q") & (cards_karo[card_num] != "K") & (cards_karo[card_num] != "A"))
                    {
                        sum += Int32.Parse(cards_karo[card_num]);
                    }
                    else if (cards_karo[card_num] == "A")
                    {
                        if (sum < 11)
                        {
                            sum += 11;
                        }
                        else
                        {
                            ++sum;
                        }
                    }
                    else
                    {
                        sum += 10;
                    }
                    if (sum > 21)
                    {
                        label1.Text = "Túlmentél";
                        label4.Text = "Vesztettél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else if (sum == 21)
                    {
                        label1.Text = "BLACKJACK";
                        label4.Text = "Nyertél";
                        label4.Visible = true;
                        button3.Visible = true;
                        return;
                    }
                    else
                    {
                        cards_karo = cards_karo.Where((source, index) => index != card_num).ToArray();
                        label1.Text = $"Összeg: {sum}";
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cards_pick = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            cards_korr = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            cards_tref = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            cards_karo = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            while (banksum < 18)
            {
                if ((banksum < 14))
                {
                    int card_type = deck.Next(1, 5);
                    int card_num;
                    Application.DoEvents();
                    switch (card_type)
                    {
                        case 1:
                            card_num = num.Next(0, cards_pick.Length);
                            listBox2.Items.Add($"Pick {cards_pick[card_num]}");
                            Application.DoEvents();
                            Thread.Sleep(500);

                            if ((cards_pick[card_num] != "J") & (cards_pick[card_num] != "Q") & (cards_pick[card_num] != "K") & (cards_pick[card_num] != "A"))
                            {
                                banksum += Int32.Parse(cards_pick[card_num]);
                            }
                            else if (cards_pick[card_num] == "A")
                            {
                                if (banksum < 11)
                                {
                                    banksum += 11;
                                }
                                else
                                {
                                    ++banksum;
                                }
                            }
                            else
                            {
                                banksum += 10;
                            }
                            if (banksum > 21)
                            {
                                label2.Text = "A Bank túlment";
                                label4.Text = "Nyertél";
                                label4.Visible = true;
                                button3.Visible = true;

                                return;
                            }
                            else if (banksum == 21)
                            {
                                label2.Text = "BANK BLACKJACK";
                                label4.Text = "Vesztettél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else
                            {
                                cards_pick = cards_pick.Where((source, index) => index != card_num).ToArray();
                                label2.Text = $"Bank összeg: {banksum}";
                                Application.DoEvents();
                            }
                            break;
                        case 2:
                            card_num = num.Next(0, cards_korr.Length);
                            listBox2.Items.Add($"Kör {cards_korr[card_num]}");
                            Application.DoEvents();
                            Thread.Sleep(500);

                            if ((cards_korr[card_num] != "J") & (cards_korr[card_num] != "Q") & (cards_korr[card_num] != "K") & (cards_korr[card_num] != "A"))
                            {
                                banksum += Int32.Parse(cards_korr[card_num]);
                            }
                            else if (cards_korr[card_num] == "A")
                            {
                                if (banksum < 11)
                                {
                                    banksum += 11;
                                }
                                else
                                {
                                    ++banksum;
                                }
                            }
                            else
                            {
                                banksum += 10;
                            }
                            if (banksum > 21)
                            {
                                label2.Text = "A Bank túlment";
                                label4.Text = "Nyertél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else if (banksum == 21)
                            {
                                label2.Text = "BANK BLACKJACK";
                                label4.Text = "Vesztettél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else
                            {
                                cards_korr = cards_korr.Where((source, index) => index != card_num).ToArray();
                                label2.Text = $"Bank összeg: {banksum}";
                                Application.DoEvents();
                            }
                            break;
                        case 3:
                            card_num = num.Next(0, cards_tref.Length);
                            listBox2.Items.Add($"Treff {cards_tref[card_num]}");
                            Application.DoEvents();
                            Thread.Sleep(500);

                            if ((cards_tref[card_num] != "J") & (cards_tref[card_num] != "Q") & (cards_tref[card_num] != "K") & (cards_tref[card_num] != "A"))
                            {
                                banksum += Int32.Parse(cards_tref[card_num]);
                            }
                            else if (cards_tref[card_num] == "A")
                            {
                                if (banksum < 11)
                                {
                                    banksum += 11;
                                }
                                else
                                {
                                    ++banksum;
                                }
                            }
                            else
                            {
                                banksum += 10;
                            }
                            if (banksum > 21)
                            {
                                label2.Text = "A Bank túlment";
                                label4.Text = "Nyertél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else if (banksum == 21)
                            {
                                label2.Text = "BANK BLACKJACK";
                                label4.Text = "Vesztettél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else
                            {
                                cards_tref = cards_tref.Where((source, index) => index != card_num).ToArray();
                                label2.Text = $"Bank összeg: {banksum}";
                                Application.DoEvents();
                            }
                            break;
                        case 4:
                            card_num = num.Next(0, cards_karo.Length);
                            listBox2.Items.Add($"Káró {cards_karo[card_num]}");
                            Application.DoEvents();
                            Thread.Sleep(500);

                            if ((cards_karo[card_num] != "J") & (cards_karo[card_num] != "Q") & (cards_karo[card_num] != "K") & (cards_karo[card_num] != "A"))
                            {
                                banksum += Int32.Parse(cards_karo[card_num]);
                            }
                            else if (cards_karo[card_num] == "A")
                            {
                                if (banksum < 11)
                                {
                                    banksum += 11;
                                }
                                else
                                {
                                    ++banksum;
                                }
                            }
                            else
                            {
                                banksum += 10;
                            }
                            if (banksum > 21)
                            {
                                label2.Text = "A Bank túlment";
                                label4.Text = "Nyertél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else if (banksum == 21)
                            {
                                label2.Text = "BANK BLACKJACK";
                                label4.Text = "Vesztettél";
                                label4.Visible = true;
                                button3.Visible = true;
                                return;
                            }
                            else
                            {
                                cards_karo = cards_karo.Where((source, index) => index != card_num).ToArray();
                                label2.Text = $"Bank összeg: {banksum}";
                                Application.DoEvents();
                            }
                            break;
                    }
                }
                else if ((banksum > 13) & (banksum < 18))
                {
                    if (yesno == 1)
                    {
                        int card_type = deck.Next(1, 5);
                        int card_num;
                        Application.DoEvents();
                        switch (card_type)
                        {
                            case 1:
                                card_num = num.Next(0, cards_pick.Length);
                                listBox2.Items.Add($"Pick {cards_pick[card_num]}");
                                Application.DoEvents();
                                Thread.Sleep(500);

                                if ((cards_pick[card_num] != "J") & (cards_pick[card_num] != "Q") & (cards_pick[card_num] != "K") & (cards_pick[card_num] != "A"))
                                {
                                    banksum += Int32.Parse(cards_pick[card_num]);
                                }
                                else if (cards_pick[card_num] == "A")
                                {
                                    if (banksum < 11)
                                    {
                                        banksum += 11;
                                    }
                                    else
                                    {
                                        ++banksum;
                                    }
                                }
                                else
                                {
                                    banksum += 10;
                                }
                                if (banksum > 21)
                                {
                                    label2.Text = "A Bank túlment";
                                    label4.Text = "Nyertél";
                                    label4.Visible = true;
                                    button3.Visible = true;

                                    return;
                                }
                                else if (banksum == 21)
                                {
                                    label2.Text = "BANK BLACKJACK";
                                    label4.Text = "Vesztettél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else
                                {
                                    cards_pick = cards_pick.Where((source, index) => index != card_num).ToArray();
                                    label2.Text = $"Bank összeg: {banksum}";
                                    Application.DoEvents();
                                }
                                break;
                            case 2:
                                card_num = num.Next(0, cards_korr.Length);
                                listBox2.Items.Add($"Kör {cards_korr[card_num]}");
                                Application.DoEvents();
                                Thread.Sleep(500);

                                if ((cards_korr[card_num] != "J") & (cards_korr[card_num] != "Q") & (cards_korr[card_num] != "K") & (cards_korr[card_num] != "A"))
                                {
                                    banksum += Int32.Parse(cards_korr[card_num]);
                                }
                                else if (cards_korr[card_num] == "A")
                                {
                                    if (banksum < 11)
                                    {
                                        banksum += 11;
                                    }
                                    else
                                    {
                                        ++banksum;
                                    }
                                }
                                else
                                {
                                    banksum += 10;
                                }
                                if (banksum > 21)
                                {
                                    label2.Text = "A Bank túlment";
                                    label4.Text = "Nyertél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else if (banksum == 21)
                                {
                                    label2.Text = "BANK BLACKJACK";
                                    label4.Text = "Vesztettél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else
                                {
                                    cards_korr = cards_korr.Where((source, index) => index != card_num).ToArray();
                                    label2.Text = $"Bank összeg: {banksum}";
                                    Application.DoEvents();
                                }
                                break;
                            case 3:
                                card_num = num.Next(0, cards_tref.Length);
                                listBox2.Items.Add($"Treff {cards_tref[card_num]}");
                                Application.DoEvents();
                                Thread.Sleep(500);

                                if ((cards_tref[card_num] != "J") & (cards_tref[card_num] != "Q") & (cards_tref[card_num] != "K") & (cards_tref[card_num] != "A"))
                                {
                                    banksum += Int32.Parse(cards_tref[card_num]);
                                }
                                else if (cards_tref[card_num] == "A")
                                {
                                    if (banksum < 11)
                                    {
                                        banksum += 11;
                                    }
                                    else
                                    {
                                        ++banksum;
                                    }
                                }
                                else
                                {
                                    banksum += 10;
                                }
                                if (banksum > 21)
                                {
                                    label2.Text = "A Bank túlment";
                                    label4.Text = "Nyertél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else if (banksum == 21)
                                {
                                    label2.Text = "BANK BLACKJACK";
                                    label4.Text = "Vesztettél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else
                                {
                                    cards_tref = cards_tref.Where((source, index) => index != card_num).ToArray();
                                    label2.Text = $"Bank összeg: {banksum}";
                                    Application.DoEvents();
                                }
                                break;
                            case 4:
                                card_num = num.Next(0, cards_karo.Length);
                                listBox2.Items.Add($"Káró {cards_karo[card_num]}");
                                Application.DoEvents();
                                Thread.Sleep(500);

                                if ((cards_karo[card_num] != "J") & (cards_karo[card_num] != "Q") & (cards_karo[card_num] != "K") & (cards_karo[card_num] != "A"))
                                {
                                    banksum += Int32.Parse(cards_karo[card_num]);
                                }
                                else if (cards_karo[card_num] == "A")
                                {
                                    if (banksum < 11)
                                    {
                                        banksum += 11;
                                    }
                                    else
                                    {
                                        ++banksum;
                                    }
                                }
                                else
                                {
                                    banksum += 10;
                                }
                                if (banksum > 21)
                                {
                                    label2.Text = "A Bank túlment";
                                    label4.Text = "Nyertél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else if (banksum == 21)
                                {
                                    label2.Text = "BANK BLACKJACK";
                                    label4.Text = "Vesztettél";
                                    label4.Visible = true;
                                    button3.Visible = true;
                                    return;
                                }
                                else
                                {
                                    cards_karo = cards_karo.Where((source, index) => index != card_num).ToArray();
                                    label2.Text = $"Bank összeg: {banksum}";
                                    Application.DoEvents();
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (sum > banksum)
                        {
                            label4.Text = "Nyertél";
                            label4.Visible = true;
                            button3.Visible = true;
                            return;
                        }
                        else if (banksum > sum)
                        {
                            label4.Text = "Vesztettél";
                            label4.Visible = true;
                            button3.Visible = true;
                            return;
                        }
                        else
                        {
                            label4.Text = "Döntetlen, vesztettél";
                            label4.Visible = true;
                            button3.Visible = true;
                            return;
                        }
                    }
                }
            }
            if (sum > banksum)
            {
                label4.Text = "Nyertél";
                label4.Visible = true;
                button3.Visible = true;
                return;
            }
            else if (banksum > sum)
            {
                label4.Text = "Vesztettél";
                label4.Visible = true;
                button3.Visible = true;
                return;
            }
            else
            {
                label4.Text = "Döntetlen, vesztettél";
                label4.Visible = true;
                button3.Visible = true;
                return;
            }


        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            cards_pick = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            cards_korr = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            cards_tref = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            cards_karo = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            sum = 0;
            banksum = 0;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label4.Visible = false;
            button3.Visible = false;
        }
    }
}

//700