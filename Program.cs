using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using System;


namespace ConsoleApp
{
    internal class Program
    {
        static void Main() // Меню
        {
            bool menu = true;
            while (menu) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No, it's not the human");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Новая игра");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("2. Информация");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("3. Выход из игры");
                Console.ResetColor();
                Console.WriteLine();
                string menuInput = Console.ReadLine();
                Console.Clear();
                if (!(menuInput == "1" || menuInput == "2" || menuInput == "3")) continue;
                switch (menuInput) 
                {
                    case "3": menu = false; break;
                    case "2": menu = PrintInfo(); break;
                    case "1": menu = BeginGame(); break;
                }

            }
        } // Done
        static bool PrintInfo() // Информация
        {
            while (true)
            {
                Console.WriteLine("Данная игра является фанатской копией игры I'm not the human");
                Console.WriteLine("Для управлением используйте ввод цифр. После введения цифры нажмите Enter");
                Console.WriteLine();
                Console.WriteLine("Сюжет игры разворачивается в альтернативной реальности в 2010 году.");
                Console.WriteLine("В мире настали неспокойные времена, днём солнце выжигает практически всё живое, и в мире появилась некая аномалия,");
                Console.WriteLine("с которой вы столкнётесь играя в игру.");
                Console.WriteLine();
                Console.WriteLine("Удачной игры, игрок!");
                Console.WriteLine();
                Console.WriteLine("1. Вернуться в главное меню");
                Console.WriteLine("2. Выйти из игры");
                Console.WriteLine();
                string infoInput = Console.ReadLine();
                Console.Clear();
                if (!(infoInput == "1" || infoInput == "2")) continue;
                if (infoInput == "1") return true;
                return false;
            }
        } // Done
        static bool BeginGame() // Игра
        {
            int iteration = 0;
            int energy = 0;
            string[,] guests = new string[12, 5];

            while (true) 
            {
                Console.WriteLine("Вы просыпаетесь в своём частном домике, рядом с хрущёвками в тихом далёком городе.");
                Console.WriteLine("Обычный день обычного программиста на удалёнке.");
                Console.WriteLine();
                Console.WriteLine("*** Тук-тук-тук ***");
                Console.WriteLine();
                Console.WriteLine("1. Включить компьютер");
                Console.WriteLine("2. Смотреть телевизор");
                Console.WriteLine("3. Идти в гостиную");
                Console.WriteLine("4. Идти на кухню");
                Console.WriteLine("5. Идти в ванную комнату");
                Console.WriteLine("6. Идти в кладовую комнату");
                Console.WriteLine("7. Посмотреть в окно");
                Console.WriteLine("8. Подойти к двери.");
                Console.WriteLine("9. Открыть настройки");
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.Clear();
                if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9")) continue;
                switch (input) 
                {
                    case "1": if (!OpenPC()) return true; break;
                    case "2": if (!WatchTV(iteration)) return true; break;
                    case "3": if (!GoToHall(guests, iteration, ref energy)) return true; break;
                    case "4": if (!GoToKitchen(guests, iteration, ref energy)) return true; break;
                    case "5": if (!GoToBathroom(guests, iteration, ref energy)) return true; break;
                    case "6": if (!GoToStoreroom(guests, iteration, ref energy)) return true; break;
                    case "7": if (!LookOutTheWindow(iteration)) return true; break;
                    case "8": if (!ComeToTheDoor(guests, iteration)) return true;
                        iteration++;
                        break;
                    case "9": if (!OpenSettings()) return true; break;
                }
                if (input != "8") continue;

                bool flag = false;
                bool flag1 = true;
                bool flag2 = true;
                string deadPeople = "";
                int counterOfDead = 0;

                while (true) 
                {
                    if (iteration % 2 != 0)
                    {
                        if (iteration == 7) 
                        {
                            while (true)
                            {
                                if (CountIllGuests(guests) != 0)
                                {
                                    Console.WriteLine("Вскоре гости которые были в вашем доме активизировались и напали на всё живое в вашем доме.");
                                    Console.WriteLine("Вы не смогли от них отбиться и вас ждала судьба хуже смерти.");
                                    Console.WriteLine();
                                    Console.WriteLine("Плохая концовка: вас убили.");
                                }
                                else
                                {
                                    Console.WriteLine("Вы выжили несмотря не на что.");
                                    Console.WriteLine("Бог знает сколько ещё вы сможете продержаться, но вы уверенно живёте");
                                    Console.WriteLine();
                                    Console.WriteLine("Хорошая концовка: вы выжили.");
                                }
                                Console.WriteLine();
                                Console.WriteLine("1. Выйи в главное меню");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1")) continue;
                                return true;
                            }
                        }
                        Console.WriteLine("Вы проснулись ночью.");
                        Console.WriteLine();
                        Console.WriteLine("*** Тук-тук ***");
                        Console.WriteLine();
                        Console.WriteLine("1. Посмотреть в окно");
                        Console.WriteLine("2. Подойти к двери.");
                        Console.WriteLine("3. Открыть настройки");
                        Console.WriteLine();
                        input = Console.ReadLine();
                        Console.Clear();
                        if (!(input == "1" || input == "2" || input == "3"))
                        {
                            continue;
                        }
                        switch (input)
                        {
                            case "1": 
                                if (!LookOutTheWindow(iteration)) return true;
                                break;
                            case "2": 
                                if (!ComeToTheDoor(guests, iteration)) return true; 
                                iteration++;
                                break;
                            case "3": 
                                if (!OpenSettings()) return true;
                                break;
                        }
                    }
                    else 
                    {
                        int counterOfLive = 0;

                        if (flag2)
                        {
                            energy = iteration;
                            flag2 = false;
                        }
                        Console.WriteLine("Вы проснулись рано утром. У вас " + energy + " энергии.");
                        int illGuests = CountIllGuests(guests);
                        int index = 0;
                        if (flag1)
                        {
                            deadPeople = "";
                            for (int j = 0; j < 12; j++)
                            {
                                if (index == illGuests) break;
                                if (guests[j, 2] == "Живой" && guests[j, 1] == "Человек")
                                {
                                    guests[j, 2] = "Мёртвый";
                                    deadPeople += " " + guests[j, 0];
                                    index++;
                                }
                            }

                            for (int i = 0; i < 12; i++)
                            {
                                if (guests[i, 2] == "Мёртвый" && guests[i, 1] == "Человек")
                                {
                                    guests[i, 2] = "Устранённый";
                                    counterOfDead++;
                                    flag = true;
                                }
                            }
                            flag1 = false;
                        }

                        for (int l = 0; l < 12; l++) // Здесь мы будем отдельно считать живых
                        {
                            if (guests[l, 2] == "Живой") counterOfLive++; // Здесь будет происходить подсчёт живых
                        }

                        if (flag)
                        { 
                            Console.WriteLine("В вашем доме " + counterOfDead + " труп(ов)(а) нормальных людей");
                            Console.WriteLine("Сегодня умерли:" + deadPeople + ".");
                        }
                        else Console.WriteLine("Ваш дом чист");
                        Console.WriteLine("В вашем доме " + counterOfLive + " живой(ых) жилец(а)");
                        Console.WriteLine();
                        Console.WriteLine("1. Включить компьютер");
                        Console.WriteLine("2. Смотреть телевизор");
                        Console.WriteLine("3. Идти в гостиную");
                        Console.WriteLine("4. Идти на кухню");
                        Console.WriteLine("5. Идти в ванную комнату");
                        Console.WriteLine("6. Идти в кладовую комнату");
                        Console.WriteLine("7. Посмотреть в окно");
                        Console.WriteLine("8. Выпить пиво и лечь спать.");
                        Console.WriteLine("9. Открыть настройки");
                        Console.WriteLine();
                        input = Console.ReadLine();
                        Console.Clear();
                        if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9"))
                        {
                            continue; 
                        }
                        switch (input)
                        {
                            case "1": 
                                if (!OpenPC()) return true;
                                break;
                            case "2": 
                                if (!WatchTV(iteration)) return true;
                                break;
                            case "3": 
                                if (!GoToHall(guests, iteration, ref energy)) return true;
                                break;
                            case "4": 
                                if (!GoToKitchen(guests, iteration, ref energy)) return true;
                                break;
                            case "5": 
                                if (!GoToBathroom(guests, iteration, ref energy)) return true; 
                                break;
                            case "6":
                                if (!GoToStoreroom(guests, iteration, ref energy)) return true;
                                break;
                            case "7": 
                                if (!LookOutTheWindow(iteration)) return true;
                                break;
                            case "8":
                                flag = false;
                                flag1 = true;
                                flag2 = true;
                                counterOfDead = 0;
                                iteration++;
                                continue;
                            case "9": 
                                if (!OpenSettings()) return true;
                                break;
                        }
                    }
                }
            }
        } // Done
        static bool OpenSettings() // Настройки
        {
            while (true)
            {
                Console.WriteLine("1. Назад");
                Console.WriteLine("2. Выйти в главное меню");
                string input = Console.ReadLine();
                Console.Clear();
                if (!(input == "1" || input == "2")) continue;
                if (input == "1") return true;
                while (true)
                {
                    Console.WriteLine("Внимание: при выходе в главное меню весь несоранённый прогрес будет утрачен!");
                    Console.WriteLine("Вы уверены, что хотите выйти в главное меню?");
                    Console.WriteLine();
                    Console.WriteLine("1. Да");
                    Console.WriteLine("2. Нет, верните меня в Настройки.");
                    input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "1") return false;
                    break;
                }

            }

        } // Done
        static bool WatchTV(int iteration) // Смотреть телевизор
        {
            while (true) 
            {
                switch (iteration) 
                {
                    case 0:
                        Console.WriteLine("Телевизор выглядет потрёпанным, старому пузатому телевизору, кажется, пора на пенсию.");
                        Console.WriteLine("Вы включаете телевизор.");
                        Console.WriteLine();
                        Console.WriteLine("Ведущий: Добрый день в эфире Новости. С вами ведущий Николай Лелебов"); 
                        Console.WriteLine("Вчера нашими астрономами на Солнце были обнаружены аномальные вспышки,");
                        Console.WriteLine("которые привели к большому выбросу тепловой энергии.");
                        Console.WriteLine("В ближайшее время ожидаются сильные климатические изменения.");
                        Console.WriteLine();
                        Console.WriteLine("Также сегодня во всей Ограндской области пропал интернет в связи с аварией на серверах.");
                        Console.WriteLine("Последствия аварии по подсчётам будут устранены примерно за 1-2 недели.");
                        Console.WriteLine("В связи с этим во всей Ограндской области для перечня работников, на чью работу повлияла авария,");
                        Console.WriteLine("выдаётся 2 недели оплачиваемого отпуска за счёт государства.");
                        Console.WriteLine();
                        Console.WriteLine("И о погоде... *** пш-пш-пш *** ....");
                        Console.WriteLine();
                        Console.WriteLine("Вы: Чёрт надо бы уже купить новый телевизор. Проклятая антена!");
                        Console.WriteLine("Хм, 2 недели оплачиваемого отпуска без интернета, уж лучше бы я работал,");
                        Console.WriteLine("Я же так со скуки помру! Ну ладно переживу.");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Телевизор выглядет потрёпанным, старому пузатому телевизору, кажется, пора на пенсию.");
                        Console.WriteLine("Вы включаете телевизор.");
                        Console.WriteLine();
                        Console.WriteLine("Ведущий: Добрый день в эфире Новости. С вами ведущий Николай Лелебов");
                        Console.WriteLine("Астрономы выяснили, что на солнце произошла очередная вспышка,");
                        Console.WriteLine("которая происходит раз в тысячу лет!");
                        Console.WriteLine("Астрономы и климатологи заявили, что пробит озоновый слой Земли,");
                        Console.WriteLine("это означает то, что теперь днём Земля не защищена от Солнечной радиации.");
                        Console.WriteLine("Рекомендуется не покидать помещения днём в связи с риском облучения или возгорания.");
                        Console.WriteLine();
                        Console.WriteLine("Голос за сценой: [непонятное бормотание]");
                        Console.WriteLine();
                        Console.WriteLine("Ведущий: Ага. Уважаемые телезрители, в эфир поступила срочная новость.");
                        Console.WriteLine("Учёные обнаружили новое заболевание: G.O.S.T, похожее на бешенство");
                        Console.WriteLine("Носители данного заболевания практически не отличаются от людей. Но внезапно они могут начать убивать людей.");
                        Console.WriteLine("Допросив выжившего очевидца, учёные выявили пока 1 признак так называемого ГОСТя:");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Идеально белые зубы.");
                        Console.ResetColor();
                        Console.WriteLine("И о политик... *** пш-пш-пш *** ....");
                        Console.WriteLine();
                        Console.WriteLine("Вы: Чёрт надо бы уже купить новый телевизор. Проклятая антена!");
                        Console.WriteLine("Хм, сосед был прав. Мне стоит проверить людей на признаки ГОСТей");
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Телевизор выглядет потрёпанным, старому пузатому телевизору, кажется, пора на пенсию.");
                        Console.WriteLine("Вы включаете телевизор.");
                        Console.WriteLine();
                        Console.WriteLine("Ведущий: Добрый день в эфире Новости. С вами ведущий Николай Лелебов");
                        Console.WriteLine("Жара вся зона в области экватора охвачена нескончаемыми пожарами, вся техника там вышла из строя,");
                        Console.WriteLine("так как все спаянные припоем детали отпаялись.");
                        Console.WriteLine("Активность же ГОСТей за последнее время по официальным данным увеличилась на 400%");
                        Console.WriteLine("Учёные выявили новый признак ГОСТей: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Красные глаза.");
                        Console.ResetColor();
                        Console.WriteLine("Из-за мутации болезни, она поражает частично органы зрения");
                        Console.WriteLine("По прежнему не рекомендуется покидать убежище.");
                        Console.WriteLine("Так же был сформирован КЧС - Комитет Черезвычайных Ситуаций, для помощи пострадавшим и ускорению выявления ГОСТей.");
                        Console.WriteLine("Опознать вы их сможете по болотистому цвету их костюмов и противогазу.");
                        Console.WriteLine("В северной Америке... *** пш-пш-пш *** ....");
                        Console.WriteLine("Угу, значит красные глаза.");
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine("Телевизор выглядет потрёпанным, старому пузатому телевизору, кажется, пора на пенсию.");
                        Console.WriteLine("Вы включаете телевизор.");
                        Console.WriteLine();
                        Console.WriteLine("Ведущий: Добрый день в эфире Новости. С вами ведущий Николай Лелебов");
                        Console.WriteLine("Жара всё усиливается, учёные прогнозируют вымирание 85% всего человечества.");
                        Console.WriteLine("Тем не менее КЧС ещё ведёт работу по разработке вакцины от G.O.S.T");
                        Console.WriteLine("Учёные выявили новый признак ГОСТей: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Кровь под ногтями");
                        Console.ResetColor();
                        Console.WriteLine("Так как ГОСТи распространяют болезнь через кровь, то при контакте со своей жертве они царапают её, тем самым заражая кровь.");
                        Console.WriteLine("В в связи с... *** пш-пш-пш *** ....");
                        Console.WriteLine("Угу, значит ковь под ногтями.");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine("1. Выключить телевизор");
                Console.WriteLine("2. Открыть настройки");
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.Clear();
                if (!(input == "1" || input == "2")) continue;
                if (input == "1") return true;
                if (OpenSettings()) continue; // Работа с настройками
                return false;
            }
        } // Done
        static bool OpenPC() // Открыть комп
        {
            while (true)
            {
                Console.WriteLine("Вы включаете компьютер, но на нём нет интернета.");
                Console.WriteLine();
                Console.WriteLine("Вы: Чёрт интернет...");
                Console.WriteLine("У меня почти всё работает через интернет,");
                Console.WriteLine("похоже сейчас компьютер бесполезен.");
                Console.WriteLine();
                Console.WriteLine("1. Выключить компьютер");
                Console.WriteLine("2. Открыть настройки");
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.Clear();
                if (!(input == "1" || input == "2")) continue;
                if (input == "1") return true;
                if (OpenSettings()) continue; // Работа с настройками
                return false;
            }
        } // Done
        static bool GoToHall(string[,] guests, int iteration, ref int energy) // Идти в гостиную
        {
            while (true)
            {
                if (iteration == 0 || CountInRoom(guests, "Гостиная") == 0)
                {
                    Console.WriteLine("Вы зашли в гостиную, но там никого нет.");
                    Console.WriteLine();
                    Console.WriteLine("1. Вернуться назад");
                    Console.WriteLine("2. Открыть настройки");
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "1") return true;
                    if (OpenSettings()) continue; // Работа с настройками
                    return false;
                }
                else
                {
                    Console.WriteLine("В гостиной сидят " + CountInRoom(guests, "Гостиная") + " жилец(ов).");
                    Console.WriteLine("У вас " + energy + " энергии");
                    string[,] testArray = new string[12, 2];
                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        if (guests[i, 0] != null && guests[i, 3] == "Гостиная" && guests[i, 2] == "Живой")
                        {
                            testArray[index, 0] = guests[i, 0];
                            testArray[index, 1] = i.ToString();
                            index++;
                        }
                    }
                    Console.WriteLine();
                    int counter = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        if (testArray[j, 0] != null) 
                        {
                            Console.WriteLine(j + 1 + ". Поговорить с жильцом " + testArray[j, 0]);
                            counter++;
                        }
                    }
                    Console.WriteLine(counter + 1 + ". Открыть настройки");
                    Console.WriteLine(counter + 2 + ". Вернуться назад");
                    counter++;
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9" || input == "10" || input == "11" || input == "12")) continue;
                    if (int.Parse(input) > counter + 1) continue;
                    if (int.Parse(input) == counter) 
                    {
                        if (OpenSettings()) continue; // Работа с настройками
                        return false;
                    }
                    if (int.Parse(input) == counter + 1) return true;
                    energy -= TalkWithGuests(guests, testArray, iteration, input, energy);
                }
            }
        } // Done
        static bool GoToKitchen(string[,] guests, int iteration, ref int energy) // Идти на кухню
        {
            while (true)
            {
                if (iteration == 0 || CountInRoom(guests, "Кухня") == 0)
                {
                    Console.WriteLine("Вы зашли на кухню, но там никого нет.");
                    Console.WriteLine();
                    Console.WriteLine("1. Вернуться назад");
                    Console.WriteLine("2. Открыть настройки");
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "1") return true;
                    if (OpenSettings()) continue; // Работа с настройками
                    return false;
                }
                else
                {
                    Console.WriteLine("На кухне сидят " + CountInRoom(guests, "Кухня") + " жилец(ов).");
                    Console.WriteLine("У вас " + energy + " энергии");
                    string[,] testArray = new string[12, 2];
                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        if (guests[i, 0] != null && guests[i, 3] == "Кухня" && guests[i, 2] == "Живой")
                        {
                            testArray[index, 0] = guests[i, 0];
                            testArray[index, 1] = i.ToString();
                            index++;
                        }
                    }
                    Console.WriteLine();
                    int counter = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        if (testArray[j, 0] != null)
                        {
                            Console.WriteLine(j + 1 + ". Поговорить с жильцом " + testArray[j, 0]);
                            counter++;
                        }
                    }
                    Console.WriteLine(counter + 1 + ". Открыть настройки");
                    Console.WriteLine(counter + 2 + ". Вернуться назад");
                    counter++;
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9" || input == "10" || input == "11" || input == "12")) continue;
                    if (int.Parse(input) > counter + 1) continue;
                    if (int.Parse(input) == counter)
                    {
                        if (OpenSettings()) continue; // Работа с настройками
                        return false;
                    }
                    if (int.Parse(input) == counter + 1) return true;
                    energy -= TalkWithGuests(guests, testArray, iteration, input, energy);
                }
            }
        } // Done
        static bool GoToBathroom(string[,] guests, int iteration, ref int energy) // Идти в ванную
        {
            while (true)
            {
                if (iteration == 0 || CountInRoom(guests, "Ванная") == 0)
                {
                    Console.WriteLine("Вы зашли в ванную, но там никого нет.");
                    Console.WriteLine();
                    Console.WriteLine("1. Вернуться назад");
                    Console.WriteLine("2. Открыть настройки");
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "1") return true;
                    if (OpenSettings()) continue; // Работа с настройками
                    return false;
                }
                else
                {
                    Console.WriteLine("В ванной сидят " + CountInRoom(guests, "Ванная") + " жилец(ов).");
                    Console.WriteLine("У вас " + energy + " энергии");
                    string[,] testArray = new string[12, 2];
                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        if (guests[i, 0] != null && guests[i, 3] == "Ванная" && guests[i, 2] == "Живой")
                        {
                            testArray[index, 0] = guests[i, 0];
                            testArray[index, 1] = i.ToString();
                            index++;
                        }
                    }
                    Console.WriteLine();
                    int counter = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        if (testArray[j, 0] != null)
                        {
                            Console.WriteLine(j + 1 + ". Поговорить с жильцом " + testArray[j, 0]);
                            counter++;
                        }
                    }
                    Console.WriteLine(counter + 1 + ". Открыть настройки");
                    Console.WriteLine(counter + 2 + ". Вернуться назад");
                    counter++;
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9" || input == "10" || input == "11" || input == "12")) continue;
                    if (int.Parse(input) > counter + 1) continue;
                    if (int.Parse(input) == counter)
                    {
                        if (OpenSettings()) continue; // Работа с настройками
                        return false;
                    }
                    if (int.Parse(input) == counter + 1) return true;
                    energy -= TalkWithGuests(guests, testArray, iteration, input, energy);
                }
            }
        } // Done
        static bool GoToStoreroom(string[,] guests, int iteration, ref int energy) // Идти в кладовую
        {
            while (true)
            {
                if (iteration == 0 || CountInRoom(guests, "Кладовая") == 0)
                {
                    Console.WriteLine("Вы зашли в кладовую, но там никого нет.");
                    Console.WriteLine();
                    Console.WriteLine("1. Вернуться назад");
                    Console.WriteLine("2. Открыть настройки");
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "1") return true;
                    if (OpenSettings()) continue; // Работа с настройками
                    return false;
                }
                else
                {
                    Console.WriteLine("В кладовой сидят " + CountInRoom(guests, "Кладовая") + " жилец(ов).");
                    Console.WriteLine("У вас " + energy + " энергии");
                    string[,] testArray = new string[12, 2];
                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        if (guests[i, 0] != null && guests[i, 3] == "Кладовая" && guests[i, 2] == "Живой")
                        {
                            testArray[index, 0] = guests[i, 0];
                            testArray[index, 1] = i.ToString();
                            index++;
                        }
                    }
                    Console.WriteLine();
                    int counter = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        if (testArray[j, 0] != null)
                        {
                            Console.WriteLine(j + 1 + ". Поговорить с жильцом " + testArray[j, 0]);
                            counter++;
                        }
                    }
                    Console.WriteLine(counter + 1 + ". Открыть настройки");
                    Console.WriteLine(counter + 2 + ". Вернуться назад");
                    counter++;
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9" || input == "10" || input == "11" || input == "12")) continue;
                    if (int.Parse(input) > counter + 1) continue;
                    if (int.Parse(input) == counter)
                    {
                        if (OpenSettings()) continue; // Работа с настройками
                        return false;
                    }
                    if (int.Parse(input) == counter + 1) return true;
                    energy -= TalkWithGuests(guests, testArray, iteration, input, energy);
                }
            }
        } // Done
        static bool LookOutTheWindow(int iteration) // Посмотреть в окно
        {
            while (true) 
            {
                switch (iteration) 
                {
                    case 0: 
                        Console.WriteLine("Вы открыли штору и выглянули в окно. Напротив стоит дом соседа.");
                        Console.WriteLine("Термометр у окна показывает отметку в 37 градусов.");
                        Console.WriteLine("Подумать только, ещё никогда в этом городе не было такой температуры!");
                        Console.WriteLine("Кажется, что солнечные лучи обжигают вашу кожу через окно.");
                        Console.WriteLine();
                        Console.WriteLine("Вы: Фига-се как жарко. В первый раз вижу подобную температуру.");
                        Console.WriteLine("Интересно как сосед справляется с этой летней жарой?");
                        Console.WriteLine();
                        break;
                    case 1: 
                        Console.WriteLine("Вы открыли штору и выглянули в окно. Напротив стоит дом соседа.");
                        Console.WriteLine("Термометр у окна показывает отметку в 10 градусов.");
                        Console.WriteLine("Похоже лишь покров ночи спасёт вас от адской жары.");
                        Console.WriteLine("Эту прекрасную картину портят лишь пьяницы, валяющиеся у забора соседа.");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Вы открыли штору и выглянули в окно. Напротив стоит дом соседа.");
                        Console.WriteLine("Термометр у окна показывает отметку в 59 градусов.");
                        Console.WriteLine("На дороге лежат растерзаные и обгоревшие трупы");
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Вы открыли штору и выглянули в окно. Напротив стоит горит дом соседа.");
                        Console.WriteLine("Термометр у окна показывает отметку в 15 градусов.");
                        Console.WriteLine("Похоже лишь покров ночи спасёт вас от адской жары.");
                        Console.WriteLine("Трупов у дороги уже нет, но там стоит жуткое человекоподобное существо,");
                        Console.WriteLine("кажется, что кожа на нём ему не принадлежит");
                        Console.WriteLine("В дали вы видите людей в болотных ОЗК и противогазах.");
                        Console.WriteLine();
                        break;
                    default:
                        if (iteration % 2 == 0)
                        {
                            Console.WriteLine("Вы открываете штору, но солнечные лучи обжигают вас, оставляя сильный ожог.");
                            Console.WriteLine("Пластиковй термометр деформировался под действием тепла и вы ничего не можете определить.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Термометр у окна деформирован из-за жары, несмотря на ночь вы ощущаете лёгкую жару.");
                            Console.WriteLine("Напротив стоит уже обгоревший дом соседа. В далеке вы видите бледного человека, держащего оторваную голову КЧСника");
                            Console.WriteLine("Он стоит неподвижно и улыбается вам.");
                            Console.WriteLine();
                        }
                        break;
                }
                Console.WriteLine("1. Отойти от окна");
                Console.WriteLine("2. Открыть настройки");
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.Clear();
                if (!(input == "1" || input == "2")) continue;
                if (input == "1") return true;
                if (OpenSettings()) continue; // Работа с настройками
                return false;
            }
        } // Done
        static bool ComeToTheDoor(string[,] guests, int iteration) // Подойти к двери
        {
            while (true) 
            {
                switch (iteration) 
                {
                    case 0: // Диалог 1
                        while (true)
                        {
                            Console.WriteLine("Вы подошли к двери, в которую кто-то стучится."); // Сосед
                            Console.WriteLine("Вы казались удивлёнными, ведь вы не ждали никого в гости.");
                            Console.WriteLine();
                            Console.WriteLine("Вы подошли к двери и посмотрели в глазок.");
                            Console.WriteLine("Там стоял ваш сосед.");
                            Console.WriteLine();
                            Console.WriteLine("Вы: Привет, Михалыч, вот уж кого-кого, а тебя я не ожидал увидеть. Чем могу помочь?");
                            Console.WriteLine();
                            Console.WriteLine("Сосед: Да так, посидеть, поговорить по душам пришёл, открывай быстрее, жарко на улице стоять.");
                            Console.WriteLine();
                            Console.WriteLine("Вы впустили своего соседа в дом и прошли с ним на кухню,");
                            Console.WriteLine("Только сейчавс вы заметили, что у соседа с собой ящик пива.");
                            Console.WriteLine("Видимо разговор будет серьёзный.");
                            Console.WriteLine();
                            Console.WriteLine("Сосед: Короче, не буду долго тянуть. Я пришёл тебя предупредить.");
                            Console.WriteLine();
                            Console.WriteLine("1. О чём предупредить?");
                            Console.WriteLine("2. Вот так сразу и без прелюдий?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "2")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Сосед: Да, у меня совсем нет сил из-за жары, так что сообщаю тебе только самую необходимую информацию.");
                                    Console.WriteLine("Ну так вот мне надо предупредить тебя.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. О чём предупредить?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (input != "1") continue;
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Сосед: Короче ты же знаешь мою двоюродную сестру?");
                                Console.WriteLine();
                                Console.WriteLine("Вы: Это та, которая в ментовке работает?");
                                Console.WriteLine();
                                Console.WriteLine("Сосед: Да-да. Ну так вот, она к гос-органам поближе и ей известно то, что обычному люду неизвестно");
                                Console.WriteLine();
                                Console.WriteLine("Вы: Да? Ну и что же?");
                                Console.WriteLine();
                                Console.WriteLine("Сосед: В городе нашем убийца завёлся какой-то, его первыми жертвами стали сотрудники морга.");
                                Console.WriteLine("Ублюдок убил почти всех в здании морга и мужчин, и женщин и пожилых людей, причём самым жестоким способом.");
                                Console.WriteLine("Его не смогли даже охраники с табельным остановить, Бог знает что это за персонаж такой и почему он выбрал морг,");
                                Console.WriteLine("однако выжили лишь 4 человек, которые находились в 1 кабинете.");
                                Console.WriteLine("По их словам, бледный, жуткий силуэт подошёл к их двери и спросил мол одни ли они.");
                                Console.WriteLine("А самый смелый из них сказал, что их тут четверо, и убийца их не тронул.");
                                Console.WriteLine("Походу он расправляется с жертвами только по одиночке.");
                                Console.WriteLine("Помимо всего прочего из-за вспышки на Солнце появился какой-то вирус, Бог пойми откуда.");
                                Console.WriteLine("Вирус заражает людей неким подобием бешенства что-ли. Симптомов пока никаких не наблюдается,");
                                Console.WriteLine("однако скоро по новостям объявят об этой заразе и что нужно делать.");
                                Console.WriteLine("Сами же заражёные практически не отличаются от людей, однако стоит только потерять бдительность и они убьют любого, кто попадётся под руку.");
                                Console.WriteLine("Так же жара с каждым днём всё усиливается, так что нам придётся поменять свой режим на ночной, хе-хе.");
                                Console.WriteLine("Короче, тебе надо набирать в доме как можно больше людей и проверять каждого на наличие вируса, знаю тебе не нравятся");
                                Console.WriteLine("шумные компании, но иначе никак. Разговаривай с людьми днём, а впускай гостей ночью, помни,");
                                Console.WriteLine("что проверка занимает у тебя силы, которых и так мало, так что трать силы с умом.");
                                Console.WriteLine("Если ты не хочешь ни с кем разговаривать, то выпей пиво, которое я тебе принёс.");
                                Console.WriteLine("Ладно, пока на улице жарко, мне лучше не выходить, так что останусь у тебя до ночи, хе-хе.");
                                Console.WriteLine();
                                Console.WriteLine("Вы: Ого, сколько информации. Ладно обосновывайся, а я спать");
                                Console.WriteLine();
                                Console.WriteLine("1. Выпить пиво и идти спать");
                                Console.WriteLine("2. Настройки");
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1") return true;
                                if (OpenSettings()) continue; // Работа с настройками
                                return false;
                            }
                            break;
                        }
                        break;

                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Вы подходите к двери. Похоже придётся принимать к себе людей, как и предупреждал сосед.");
                            Console.WriteLine("Вы смотрите в глазок и видите длинный силуэт стоящий у вашего глазка");
                            Console.WriteLine("За дверью стоит мужчина, 2 метра ростом в белой растрёпанной рубашке и коричневых штанах.");
                            Console.WriteLine("Его лицо выражает усталость и печаль");
                            Console.WriteLine();
                            Console.WriteLine("Марк: Здравствуй, я Марк. У тебя можно остаться?"); // Марк
                            Console.WriteLine();
                            Console.WriteLine("1. Ты кто?");
                            Console.WriteLine("2. Почему я должен тебя пустить?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Марк: Я же сказал, я Марк. Я сидел в баре с другими, но меня выгнали. Да и пошли они к чёрту,");
                                    Console.WriteLine("уже поди перерезали друг друга");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Почему тебя выгнали из бара?");
                                    Console.WriteLine("2. Ты не один из этих заражённых?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Марк: Потому что характер у меня скверный, да и сами они не ахти.");
                                        Console.WriteLine("Да и я уверен, что до завтра я бы там не дожил.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Марк: Нет, я не один из них. Ты же понимаешь, что бесмыслено задавать такой вопрос буквально всем?");
                                    }
                                    break;
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Марк: У тебя нет никакой причины пускать меня.");
                                Console.WriteLine("Я подхожу к каждому дому и прошу впустить, но все отказывают.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Ну так что? Пустишь?");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходи");
                                Console.WriteLine("2. Тебе лучше уйти...");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Марк: Спасибо. Проблем я тебе не доставлю.");
                                    guests[0, 0] = "Марк";
                                    guests[0, 1] = "Человек";
                                    guests[0, 2] = "Живой";
                                    guests[0, 3] = "Гостиная";
                                    guests[0, 4] = "Ничего";
                                    Console.WriteLine();
                                    Console.WriteLine("Вы впускаете Марка в дом.");
                                }
                                else Console.WriteLine("Марк: Ну и катись к чёрту, больно надо!");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("*** Тук-тук ***");
                        Console.WriteLine();
                        Console.WriteLine("Вы снова смотрите в глазок. В глазке вы видите маленькую девочку в белом платье."); // Лили
                        Console.WriteLine();
                        Console.WriteLine("Лили: Дядя Остап, здравствуйте, а мой папа случайно не у вас?");
                        Console.WriteLine();
                        Console.WriteLine("Вы: Ты чего ночью гуляешь? Опасно же.");
                        Console.WriteLine();
                        Console.WriteLine("Лили: Папа сказал, чтобы я днём спала и сказал, что он пошёл к вам.");
                        Console.WriteLine("Вы можете позвать папу?");
                        Console.WriteLine();
                        Console.WriteLine("Вы: Да конечно...");
                        Console.WriteLine();
                        Console.WriteLine("Ваш сосед покидает вас и уходит со своей дочкой обратно в свой дом.");
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Спустя некоторое время вы снова слышите стук"); // Игорь
                            Console.WriteLine();
                            Console.WriteLine("*** Тук-тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите обгоревшего мужчину в чёрной рабочей одежде.");
                            Console.WriteLine();
                            Console.WriteLine("Игорь: Привет дру...кхе-кхе...жище. Моё имя - Игорь. Пусти в дом, умоляю!");
                            Console.WriteLine();
                            Console.WriteLine("1. Что с тобой случилось?");
                            Console.WriteLine("2. Ты не заражён?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Игорь: Раньше я был пожарным, мы тушили загоревшиеся леса во время усиления жары.");
                                    Console.WriteLine("Вчера во время пожара все мои друзья сгорели в лесу заживо.");
                                    Console.WriteLine("Некоторым повезло, они умерли, надышавшись угарным газом, но многие сгорели заживо.");
                                    Console.WriteLine("Я же смог выжить, спрятавшись в старой шахте.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Почему ты не в больнице?");
                                    Console.WriteLine("2. Что ты чувствуешь?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Игорь: А толку от больниц? Больницы стали опаснее горящего леса, как можно доверять лечение тому,");
                                        Console.WriteLine("кому сам не доверяешь?");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Игорь: Боль и желание поспать.");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Игорь: Болезнь не выжила бы при таких термических обработках, которым подверглось моё тело.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Умоляю, кхе-кхе, пусти меня!");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходи");
                                Console.WriteLine("2. Иди своей дорогой...");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Игорь: Благодарю, я перед тобой в долгу. У меня есть какая-то справка. Может быть тебе нужна?");
                                    guests[1, 0] = "Игорь";
                                    guests[1, 1] = "Человек";
                                    guests[1, 2] = "Живой";
                                    guests[1, 3] = "Гостиная";
                                    guests[1, 4] = "Справка КЧС";
                                }
                                else Console.WriteLine("Игорь: Чёрт.");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Похоже этой ночью никто больше не прийдёт.");
                            Console.WriteLine();
                            Console.WriteLine("1. Лечь спать.");
                            Console.WriteLine("2. Настройки.");
                            Console.WriteLine();
                            string input1 = Console.ReadLine();
                            Console.Clear();
                            if (!(input1 == "1" || input1 == "2")) continue;
                            if (input1 == "1") return true;
                            if (OpenSettings()) continue; // Работа с настройками
                            return false;
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.WriteLine("Вы подходите к двери, надеясь на встречу с нормальными людьми.");
                            Console.WriteLine("Вы смотрите в глазок и видите полноватый силуэт невысокого роста");
                            Console.WriteLine("За дверью стоит женщина в длином фиолетовом платье с золотыми украшениями и ловцом снов в руках.");
                            Console.WriteLine("Её лицо выражает радость");
                            Console.WriteLine();
                            Console.WriteLine("Светлана: Привет, дорогой, я Светлана. Чувствую тёмную энергию в твём доме."); // Марк
                            Console.WriteLine();
                            Console.WriteLine("1. Чего? Какая ещё тёмная энергия?");
                            Console.WriteLine("2. Что тебе надо?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Светлана: Нечистая сила у тебя в доме, да и к тому же меркурий не в ретрограде.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Не понимаю тебя.");
                                    Console.WriteLine("2. Ты не одна из этих заражённых?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Светлана: Карты говорят, что тебе нужен проводник для очистки помещения.");
                                        Console.WriteLine("Я помогу очистить помещение.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Светлана: Дорогой, да как ты мог подумать обо мне такое?");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Светлана: Мне-то ничего не надо, это тебе нужна моя помощь.");
                                Console.WriteLine("Я помогу очистить твой дом.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Карты говорят, что тебе надо меня впустить. Послушаешь карты?");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходи.");
                                Console.WriteLine("2. Я не верю тебе. Уходи.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Светлана: Спасибо, дорогой, ты не пожалеешь.");
                                    guests[2, 0] = "Светлана";
                                    guests[2, 1] = "Гость";
                                    guests[2, 2] = "Живой";
                                    guests[2, 3] = "Кухня";
                                    guests[2, 4] = "Ничего";
                                    Console.WriteLine();
                                    Console.WriteLine("Вы впускаете Светлану в дом.");
                                }
                                else Console.WriteLine("Светлана: Будь ты проклят! Проклинаю тебя и твой дом! Проклинаю всю твою семью!");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("*** Тук  тук  тук  тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите неестествено бледный силуэт. Он широко улыбается");
                            Console.WriteLine();
                            Console.WriteLine("Маньяк: Здравствуй.");
                            Console.WriteLine();
                            Console.WriteLine("1. Мне ничего не надо!");
                            Console.WriteLine("2. У меня есть ружьё!");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                Console.WriteLine("Маньяк [улыбаясь шире]: Да-да.");
                                Console.WriteLine("У тебя просторный дом. Мне нравится.");
                            }
                            else
                            {
                                Console.WriteLine("Маньяк [улыбаясь ширe]: И это очень хорошо!");
                                Console.WriteLine("Не сомневаюсь, что у тебя дверь ещё и прочная.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Слуууушай...");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("А ты дома один?");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine("1. Я один");
                                Console.WriteLine("2. Я не один");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Маньяк: Замечательно! Тогда я войду.");
                                        Console.WriteLine();
                                        Console.WriteLine("Маньяк выламывет вашу дверь и находи вас спрятавшимся шкафу.");
                                        Console.WriteLine("Вы выяснили две вещи: пули его не берут, вам пришёл конец.");
                                        Console.WriteLine("Вас постигла судбюа хуже смерти.");
                                        Console.WriteLine("Из вашего дома ещё долго слышался протяжный крик, но вскоре он утихает.");
                                        Console.WriteLine();
                                        Console.WriteLine("Плохая концовка: Смерть.");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Вернуться в меню.");
                                        Console.WriteLine();
                                        input = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input == "1")) continue;
                                        return false;
                                    }
                                }
                                int countGuests = 0;
                                int countAllPeople = 0;
                                for (int i = 0; i < 12; i++) 
                                {
                                    if (guests[i, 2] == "Живой") countAllPeople++;
                                    if (guests[i, 2] == "Живой" && guests[i, 1] == "Гость") countGuests++;
                                }
                                if (countAllPeople == 0) 
                                {
                                    Console.WriteLine("Маньяк: Ты же знаешь, что врать нельзя?");
                                    Console.WriteLine();
                                    Console.WriteLine("Маньяк выламывет вашу дверь и находи вас спрятавшимся шкафу.");
                                    Console.WriteLine("Вы выяснили две вещи: пули его не берут, вам пришёл конец.");
                                    Console.WriteLine("Вас постигла судбюа хуже смерти.");
                                    Console.WriteLine("Из вашего дома ещё долго слышался протяжный крик, но вскоре он утихает.");
                                    Console.WriteLine();
                                    Console.WriteLine("Плохая концовка: Смерть.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Вернуться в меню.");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1")) continue;
                                    return false;
                                }
                                else if (countAllPeople == countGuests) 
                                {
                                    Console.WriteLine("Маньяк: Я ощущаю в твоём доме только гостей.");
                                    Console.WriteLine("Что ж, помогу им сделать то, что они бы сделали с тобой через пару дней.");
                                    Console.WriteLine();
                                    Console.WriteLine("Маньяк выламывет вашу дверь и находи вас спрятавшимся шкафу.");
                                    Console.WriteLine("Вы выяснили две вещи: пули его не берут, вам пришёл конец.");
                                    Console.WriteLine("Вас постигла судбюа хуже смерти.");
                                    Console.WriteLine("Из вашего дома ещё долго слышался протяжный крик, но вскоре он утихает.");
                                    Console.WriteLine();
                                    Console.WriteLine("Плохая концовка: Смерть.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Вернуться в меню.");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1")) continue;
                                    return false;
                                }
                                else 
                                {
                                    Console.WriteLine("Маньяк [скорчив хмурую гримасу]: Сегодня тебе повезло, но кто знает, что будет в другой день.");
                                }
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Спустя некоторое время вы снова слышите стук");
                            Console.WriteLine();
                            Console.WriteLine("*** Тук-тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите маленькую девочку лет 9.");
                            Console.WriteLine("Это дочь вашего соседа - Лили.");
                            Console.WriteLine();
                            Console.WriteLine("Лили [плача]: Дядя Остап, помогите, мне страаашно!");
                            Console.WriteLine();
                            Console.WriteLine("1. Что случилось?");
                            Console.WriteLine("2. Ты не заражена вирусом?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Лили: Папа сидел с людьми и разговаривал за столом, как вдруг они напали на него.");
                                    Console.WriteLine("Они убили его и пытались поджечь дом.");
                                    Console.WriteLine("Я убежала.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Почему они тебя не тронули?");
                                    Console.WriteLine("2. Ты уверена, что твой отец мёртв?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Лили: Я вышла на улицу, подышать воздухом и в окно кухни увидела,");
                                        Console.WriteLine("как они убили папу и я сразу побежала к вам.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Лили: Да уверена.");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Лили: Я не знааааю. Они убили моего отца и подожгли дом.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Дядя Остап, пустите меня, вдруг они поймают меня.");
                                Console.WriteLine();
                                Console.WriteLine("1. Заходи, выпей чай, успокойся.");
                                Console.WriteLine("2. Обратись в полицию недалеко.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Лили [всхлипывая]: Спасибо.");
                                    guests[3, 0] = "Лили";
                                    guests[3, 1] = "Человек";
                                    guests[3, 2] = "Живой";
                                    guests[3, 3] = "Кухня";
                                    guests[3, 4] = "Ничего";
                                }
                                else Console.WriteLine("Лили ревёт и убегает.");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Похоже этой ночью никто больше не прийдёт.");
                            Console.WriteLine();
                            Console.WriteLine("1. Лечь спать.");
                            Console.WriteLine("2. Настройки.");
                            Console.WriteLine();
                            string input1 = Console.ReadLine();
                            Console.Clear();
                            if (!(input1 == "1" || input1 == "2")) continue;
                            if (input1 == "1") return true;
                            if (OpenSettings()) continue; // Работа с настройками
                            return false;
                        }
                        break;
                    case 5:
                        while (true)
                        {
                            Console.WriteLine("Вы подходите к двери, надеясь на встречу с нормальными людьми.");
                            Console.WriteLine("Вы смотрите в глазок и видите низкий, худой силуэт с кривой осанкой.");
                            Console.WriteLine("За дверью лысый, улыбчивый мужчина.");
                            Console.WriteLine("Её лицо выражает радость, а зрачки имеют разный размер.");
                            Console.WriteLine();
                            Console.WriteLine("Вольдемар: Пр-р-риветствую домовладелец! Я Вольдемар-р-р."); // Марк
                            Console.WriteLine();
                            Console.WriteLine("1. Ты обкуреный?");
                            Console.WriteLine("2. Ты не гость?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Вольдемар: Бр-р-ратан пойми, времена тяжёлые, нынче никак.");
                                    Console.WriteLine("Во всяком случае я уверен, что ты мужик чёткий и пустишь меня.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Как ты вообще сюда дошёл?");
                                    Console.WriteLine("2. Ты не контактировал с заражёными?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Вольдемар: Ну как пришёл, так и дошёл");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вольдемар: Бр-р-ратан, блин буду, не контачил ни с кем.");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вольдемар: Мамой клянусь, не гость.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Ну так что? Пустишь?");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходи, но чтоб никаких веществ в доме!");
                                Console.WriteLine("2. У меня тут не наркопритон. Вали отсюда.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Вольдемар: Бр-р-ратишка от души.");
                                    guests[4, 0] = "Вольдемар";
                                    guests[4, 1] = "Гость";
                                    guests[4, 2] = "Живой";
                                    guests[4, 3] = "Ванная";
                                    guests[4, 4] = "Ничего";
                                    Console.WriteLine();
                                    Console.WriteLine("Вы впускаете Вольдемара в дом.");
                                }
                                else Console.WriteLine("Вольдемар: У, собака, я тебе устрою сладкую жизнь.");
                                break;
                            }
                            break;
                        }
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("*** Тук  тук  тук  тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите человека в болотном ОЗК и с противогазом.");
                            Console.WriteLine();
                            Console.WriteLine("Сотрудник КЧС: Доброй ночи. Я сотрудник КЧС.");
                            Console.WriteLine();
                            Console.WriteLine("1. Вам чего?");
                            Console.WriteLine("2. Кто вы?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                Console.WriteLine("Сотрудник КЧС: Я так понял вы домовладелец,");
                                Console.WriteLine("от вас особо ничего не требуется.");
                            }
                            else
                            {
                                Console.WriteLine("Сотрудник КЧС: Я так понял, вы телевизор не смотрите.");
                                Console.WriteLine("Смотрите телевизор, так государство поддерживает связь с вами.");
                            }
                            while (true)
                            {
                                bool flag = false;
                                Console.WriteLine("Вообщем нам нужен один жилец, если таковой у вас имеется,");
                                Console.WriteLine("для иследования вируса G.O.S.T.");
                                Console.WriteLine();
                                Console.WriteLine("1. Ладно");
                                for (int i = 0; i < 12; i++) 
                                {
                                    if (guests[i, 4] == "Справка КЧС") flag = true;
                                }
                                if (flag) Console.WriteLine("2. Отдать справку.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    int counter = 0;
                                    for (int i = 0; i < 12; i++) 
                                    {
                                        counter++;
                                        if (guests[i, 2] == "Живой") 
                                        {
                                            Console.WriteLine("Сотрудник КЧС забрал жильца под именем " + guests[i, 0]);
                                            guests[i, 2] = "Устранённый";
                                            break;
                                        }
                                    }
                                    if (counter == 12) Console.WriteLine("Сотрудник КЧС ушёл, не забрав никого.");
                                }
                                else 
                                {
                                    Console.WriteLine("Сотрудник КЧС: Угу. Извините за беспокойство");
                                }
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Спустя некоторое время вы снова слышите стук");
                            Console.WriteLine();
                            Console.WriteLine("*** Тук-тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите тучную женщину лет 50.");
                            Console.WriteLine("Это местная продавщица Галя из соседней Шестёрочки.");
                            Console.WriteLine();
                            Console.WriteLine("Галя: Ну здравствуй милок.");
                            Console.WriteLine();
                            Console.WriteLine("1. Не ожидал вас тут увидеть.");
                            Console.WriteLine("2. Вы не гость?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Галя: Угу, неспокойные времена.");
                                    Console.WriteLine("Гады выгнали меня из собственого дома.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Это были гости?");
                                    Console.WriteLine("2. Вы ещё работаете?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Галя: Да какие уж там гости. Марадёры обычные.");
                                        Console.WriteLine("Собаки, отжимают дом у слабых.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Галя: Да какой уж там. Закрылся магазин.");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Галя: Нет, я не гость. Уж не дай Бог подцепить эту заразу тьфу-тьфу-тьфу.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Ну вообщем мне нужно жильё. Пустишь? У меня сумка с консервами есть.");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходите.");
                                Console.WriteLine("2. Извините, но нет.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Галя: Ой спасибо красавчик.");
                                    guests[5, 0] = "Галя";
                                    guests[5, 1] = "Гость";
                                    guests[5, 2] = "Живой";
                                    guests[5, 3] = "Кладовая";
                                    guests[5, 4] = "Ничего";
                                }
                                else Console.WriteLine("Галя: Ну и ну. Я помнила тебя добрым.");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Спустя некоторое время вы снова слышите стук");
                            Console.WriteLine();
                            Console.WriteLine("*** Тук-тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите тощий силуэт в больших очкахи в халате.");
                            Console.WriteLine("Этот человек похож на учёного.");
                            Console.WriteLine();
                            Console.WriteLine("Дамир: Доброй ночи, меня зовут Дамир. Я ищу укрытие.");
                            Console.WriteLine();
                            Console.WriteLine("1. Вы учёный?");
                            Console.WriteLine("2. Вы не гость?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Дамир: Да, я из местной лаборатории.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Почему вы тут, а не там?");
                                    Console.WriteLine("2. Как там дела с вирусом?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Дамир: Один из гостей сбежал и заразил почти всю лабораторию,");
                                        Console.WriteLine("но я уцелел и сбежал.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Дамир: Время, время. Не всё сразу. Мы ещё работаем.");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Дамир: Нет, я не гость. Я всё же учёный, я знаю как устроен этот вирус и как им не заразиться.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Ну так что? Пустишь?");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходите.");
                                Console.WriteLine("2. Извините, но нет.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Дамир: Благодарю.");
                                    guests[6, 0] = "Дамир";
                                    guests[6, 1] = "Гость";
                                    guests[6, 2] = "Живой";
                                    guests[6, 3] = "Ванная";
                                    guests[6, 4] = "Ничего";
                                }
                                else Console.WriteLine("Дамир: Мда уж. Учёный - профессия неблагодарная.");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Спустя некоторое время вы снова слышите стук");
                            Console.WriteLine();
                            Console.WriteLine("*** Тук-тук ***");
                            Console.WriteLine();
                            Console.WriteLine("В глазке вы видите стройный силуэт в очках и форме доктора");
                            Console.WriteLine("Это старый человек, на его лице вы видите лёгкую ухмылку.");
                            Console.WriteLine();
                            Console.WriteLine("Вячеслав: Доброй ночи, меня зовут Вячеслав. Я ищу временое жильё.");
                            Console.WriteLine();
                            Console.WriteLine("1. Вы доктор?");
                            Console.WriteLine("2. Вы не гость?");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            Console.Clear();
                            if (!(input == "1" || input == "2")) continue;
                            if (input == "1")
                            {
                                while (true)
                                {
                                    Console.WriteLine("Вячеслав: Да, я приехал с другого города, так как в вашем городе они закончились.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. В каком смысле закончились?");
                                    Console.WriteLine("2. Почему ты ищешь жильё?");
                                    Console.WriteLine();
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input == "1" || input == "2")) continue;
                                    if (input == "1")
                                    {
                                        Console.WriteLine("Вячеслав: Ну часть уволилась, часть умерли,");
                                        Console.WriteLine("а часть просто бесследно исчезла");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вячеслав: Наше начальство сказало нам самим искать жильё.");
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вячеслав: Голубчик, придётся вам мне поверить наслово, но я не гость.");
                            }
                            while (true)
                            {
                                Console.WriteLine("Разрешите переночевать у вас?");
                                Console.WriteLine();
                                Console.WriteLine("1. Проходите.");
                                Console.WriteLine("2. Извините, но нет.");
                                Console.WriteLine();
                                input = Console.ReadLine();
                                Console.Clear();
                                if (!(input == "1" || input == "2")) continue;
                                if (input == "1")
                                {
                                    Console.WriteLine("Вячеслав: Благодарю.");
                                    guests[7, 0] = "Вячеслав";
                                    guests[7, 1] = "Человек";
                                    guests[7, 2] = "Живой";
                                    guests[7, 3] = "Кладовая";
                                    guests[7, 4] = "Ничего";
                                }
                                else Console.WriteLine("Вчеслав: Ну что ж поделать. Ладно. Всего хорошего.");
                                break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Похоже этой ночью никто больше не прийдёт.");
                            Console.WriteLine();
                            Console.WriteLine("1. Лечь спать.");
                            Console.WriteLine("2. Настройки.");
                            Console.WriteLine();
                            string input1 = Console.ReadLine();
                            Console.Clear();
                            if (!(input1 == "1" || input1 == "2")) continue;
                            if (input1 == "1") return true;
                            if (OpenSettings()) continue; // Работа с настройками
                            return false;
                        }
                        break;
                }
            }
        } // Done
        static int CountInRoom(string[,] guests, string input) // Подсчёт людей в комнате
        {
            int count = 0;
            for (int i = 0; i < 12; i++) 
            {
                if (guests[i, 3] == input && guests[i, 2] == "Живой") count++;
            }
            return count;
        } // Done
        static int TalkWithGuests(string[,] guests, string[,] testArray, int iteration, string input, int energy) 
        {
            string name = testArray[int.Parse(input) - 1, 0];
            int lostEnergy = 0;

            switch (name) 
            {
                case "Марк":
                    while (true)
                    {
                        Console.WriteLine("Марк: Спасибо за предоставленое жильё, проблем я тебе не принесу");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Что думаешь на счёт гостей?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2") 
                        {
                            while (true)
                            {
                                Console.WriteLine("Марк: Жуткие типы, никому нельзя доверять, но мне если честно уже всё равно.");
                                Console.WriteLine();
                                Console.WriteLine("1. Ок");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3") 
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Марк: Пытаешься проверить не гость ли я?");
                                Console.WriteLine("Мда уж, я был о тебе мнения выше.");
                                Console.WriteLine();
                                Console.WriteLine("Марк показывает свои зубы, но они имеют желтоватый оттенок.");
                                Console.WriteLine();
                                Console.WriteLine("Марк: Доволен?");
                                Console.WriteLine();
                                Console.WriteLine("1. Да");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "4") 
                        {
                            lostEnergy++;
                            while (true) 
                            {
                                Console.WriteLine("Марк: Как же ты задолбал со своими проверками. Вот наслаждайся.");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Марка не красные, но имеют желтоватый окрас.");
                                Console.WriteLine();
                                Console.WriteLine("Марк: Доволен?");
                                Console.WriteLine();
                                Console.WriteLine("1. Да");
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "5") 
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Марк: Что? Как вообще по пальцам можно определить кто гость а кто нет? Бред");
                                Console.WriteLine();
                                Console.WriteLine("Руки Марка чистые, а под пальцами ничего нет.");
                                Console.WriteLine();
                                Console.WriteLine("Марк: Доволен?");
                                Console.WriteLine();
                                Console.WriteLine("1. Да");
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                    }
                    break;
                case "Игорь":
                    while (true)
                    {
                        Console.WriteLine("Игорь: Кхк-кхк спасибо за предоставленое место, тут мне будет легче умирать.");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Как могли загореться деревья, да так, чтобы пожарная бригада не справилась?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Игорь: Деревья возгорали как спички, жара была слишком сильная,");
                                Console.WriteLine("солнечные лучи сожгли сухие листья и древесину в считаные мгновения");
                                Console.WriteLine();
                                Console.WriteLine("1. Ок");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            while (true)
                            {
                                Console.WriteLine("Игорь: В шахте особо негде было почистить зубы знаешь ли.");
                                Console.WriteLine();
                                Console.WriteLine("Игорь показывает свои зубы, и они в ужасном состоянии, частями виднеется зола на зубах.");
                                Console.WriteLine();
                                Console.WriteLine("Игорь: Всё?");
                                Console.WriteLine();
                                Console.WriteLine("1. Да");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            lostEnergy++;
                            continue;
                        }
                        if (input1 == "4")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Игорь: Погляди в мои глаза, прочувствуй тот ужас со мной!");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Игоря безжизненные и сильно красные.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Игорь: Ого, не ожидал. Пожалуйста даруй мне быструю смерть, я не могу перенести эти ожоги и радиацию!");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Игоря упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Игорь") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Игорь: Почему ты не облегчил мои страдания?");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Не сдавайся, я верю тебе");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "5")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Игорь: Эти руки спасли меня в шахте, помогя вырыть воздушный карман.");
                                Console.WriteLine();
                                Console.WriteLine("Руки Игоря были обгоревшие и грязные, под ногтям была черноватая субстанция.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Игорь: Ого, не ожидал. Пожалуйста даруй мне быструю смерть, я не могу перенести эти ожоги и радиацию!");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Игоря упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Игорь") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Игорь: Почему ты не облегчил мои страдания?");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Не сдавайся, я верю тебе");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                    }
                    break;
                case "Светлана":
                    while (true)
                    {
                        Console.WriteLine("Светлана: Дорогой, вижу тёмную энергию вокруг тебя. Давай погадаю?");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Погадай мне.");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Светлана: Карты говорят, что ты наивен и беспечен,");
                                Console.WriteLine("это и станет причиной конца прибывания души в твоём теле.");
                                Console.WriteLine();
                                Console.WriteLine("1. Мда уж.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Светлана: Дорогой, а зачем зубы? Они новые, недавно ставила.");
                                Console.WriteLine();
                                Console.WriteLine("Светлана показывает зубы и вы видите золотые зубы в перемешку с идеально белыми зубами.");
                                Console.WriteLine();
                                Console.WriteLine("Светлана: Всё?");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Светлана [плача]: Я не гость. Я признаюсь, я обманывала людей и накопила тем самым на зубы.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Светланы упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Светлана") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Светлана: Я обманывала детей и пенсионеров, прости меня Господь, я больше так не буду!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Жалкое зрелище.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "4")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Светлана: Посмотри в мои честные глаза, в них ты сможешь увидеть будущее.");
                                Console.WriteLine();
                                Console.WriteLine("В отражении глаз светланы вы на миг увидели тень. Глаза Светланы были красные.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Светлана: Я немного устала с дороги, поэтому и красные глаза.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Светланы упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Светлана") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Светлана: Спасибо тебе, добрый человек!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Я буду следить за тобой!");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "5")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Светлана: Ты тоже гадаешь по рукам? Ну удиви.");
                                Console.WriteLine();
                                Console.WriteLine("Под ногтями у светланы виднелась засохшая кровь");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Светлана: Стой, не стреляй, это грязь! Я испачкалась просто.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Светланы упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Светлана") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Светлана: Спасибо тебе, добрый человек, судьба наградит тебя!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Угу.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                    }
                    break;
                case "Галя":
                    while (true)
                    {
                        Console.WriteLine("Галя: Ну привет, красавчик.");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Как думаешь что будет дальше?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Галя: Ой, милок, не знаю что там будет завтра, но одно ясно точно,");
                                Console.WriteLine("гости нам покоя не дадут.");
                                Console.WriteLine();
                                Console.WriteLine("1. Увы.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Галя: Ты проверяешь не гость ли я. Помни, что признаки вторичны и могут зависеть и от других обстоятельств!");
                                Console.WriteLine();
                                Console.WriteLine("Зубы Гали идеально белые");
                                Console.WriteLine();
                                Console.WriteLine("Галя: Недавно я была у дантиста.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Галя: Стой, не стреляй!");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Гали упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Галя") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Галя: Спасибо, что выслушал!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Я уже не знаю кому можно верить.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "4")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Галя: Предупреждаю, я не спала 2 дня.");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Гали были красные.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Галя: Поверь мне, я не буду тебе врать.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Гали упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Галя") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Галя: Спасибо, что выслушал!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Я уже не знаю кому можно верить.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "5")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Галя: Я работала с мясом и забыла помыть руки.");
                                Console.WriteLine();
                                Console.WriteLine("Под ногтями у Гали виднелась засохшая кровь");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Галя: Я пойму если ты не поверишь мне, я бы на твоём месту тоже бы выстрелила.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Гали упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Галя") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Галя: Спасибо, что выслушал!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Я уже не знаю кому можно верить.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                    }
                    break;
                case "Вольдемар":
                    while (true)
                    {
                        Console.WriteLine("Вольдемар: Пр-р-риветствую домовладелец!");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Что думаешь на счёт жары?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Вольдемар: Жар-р-ра - это благодать Господня, она выжжет все грехи с нашей планеты и");
                                Console.WriteLine("мы выйдем в новый очищенный мир.");
                                Console.WriteLine();
                                Console.WriteLine("1. Уж лучше бы не спрашивал.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Вольдемар: Возр-р-ри мои идеальные, как моя душа, зубы!");
                                Console.WriteLine();
                                Console.WriteLine("Зубы Вольдемара сияют как улыбка на его лице.");
                                Console.WriteLine();
                                Console.WriteLine("Вольдемар: Ну что? Нравится?");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Вольдемар: Хо-хо, др-р-руг, зачем нам эти ссоры?");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Вольдемара упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Вольдемар") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Вольдемар: Благодар-р-рствую!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. На этот раз поверю тебе.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "4")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Вольдемар: Внимай моему взгляду!");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Вольдемара выражали бешеный взгляд и имели кроваво-красный цвет.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Вольдемар: Др-р-ружище ты чего? Никогда не употреблял? Хо-хо!");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Вольдемара упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Вольдемар") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Вольдемар: Ну так хочешь попробовать?");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Отвали торчок!");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "5")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Вольдемар: О да, посмотр-р-ри на мои руки!");
                                Console.WriteLine();
                                Console.WriteLine("Под ногтями у Вольдемара виднелась засохшая кровь");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Вольдемар: Извини др-р-ружище, но у меня чесотка, вот уже до крови расчесал себя.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Вольдемара упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Вольдемар") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Вольдемар: Господь милостив ко мне!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Живи пока.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                    }
                    break;
                case "Дамир":
                    while (true)
                    {
                        Console.WriteLine("Даимир: Добрый день!");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Что думаешь на счёт жары?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Дамир: Такое событие - это естественное явление, я уверен, что мы как вид");
                                Console.WriteLine("с лёгкостью выживем.");
                                Console.WriteLine();
                                Console.WriteLine("1. Наверное.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Дамир: Данные признаки являются лишь показателями вероятности, всё равно что подбрасывать монетку и тем самым определять гость ли человек.");
                                Console.WriteLine();
                                Console.WriteLine("Зубы Дамира были идеально белыми");
                                Console.WriteLine();
                                Console.WriteLine("Дамир: Дисциплина и правильный уход за собой делают своё дело.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Дамир: Я то думал мы цивилизованные люди!");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Дамира упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Дамир") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Дамир: В моих глазах вы пали, совершив такой поступок!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Сиди и не рыпайся. Скажи спаибо, что я вообще тебя пустил.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "4")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Дамир: Данные признаки являются лишь показателями вероятности, всё равно что подбрасывать монетку и тем самым определять гость ли человек.");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Дамира красные.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Дамир: Я то думал, что мы цивилизованные люди. Я между прочим не спал делаю научный проект и вот как люди меня благодарят!");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Даимира упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Вольдемар") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Дамир: Хм, я пересмотрю своё мнение о вашем поступке!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Не дави на меня, думаешь мне легко?");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "5")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Дамир: Данные признаки являются лишь показателями вероятности, всё равно что подбрасывать монетку и тем самым определять гость ли человек.");
                                Console.WriteLine();
                                Console.WriteLine("Под ногтями у Даимира виднелась засохшая кровь");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Дамир: Неужели ты судишь человека лишь по грязи на его руках? У меня был опыт с лабраторной крысой.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Дамира упало замертво");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Дамир") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Избавиться от тела.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Дамир: Ну и ну, не каждый день в меня тычат ружьём!");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Велком ту май хаос. Привыкай.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                    }
                    break;
                case "Лили":
                    while (true)
                    {
                        Console.WriteLine("Лили: Мне страшно");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Как выглядели те, кто напали на твоего отца?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Лили: Они выглядели как обычные люди, ничем не отличались от них.");
                                Console.WriteLine();
                                Console.WriteLine("1. Хорошо.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            lostEnergy++;
                            while (true)
                            {
                                Console.WriteLine("Лили: А зачем вам мои зубы? А я поняла, вы проверяете не гость ли я, хи-хи я тоже буду проверять всех");
                                Console.WriteLine();
                                Console.WriteLine("Молочные зубы Лили чистые.");
                                Console.WriteLine();
                                Console.WriteLine("Лили: Вам нравится? Я чищу их каждый день, как папа и говорил.");
                                Console.WriteLine();
                                Console.WriteLine("1. Достать ружьё");
                                Console.WriteLine("2. Проигнорировать");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1" || input1 == "2")) continue;
                                if (input1 == "2") break;
                                while (true)
                                {
                                    Console.WriteLine("Лили: Что это? Можно подержать? Мне нравится эта пушка.");
                                    Console.WriteLine();
                                    Console.WriteLine("1. Выстрелить.");
                                    Console.WriteLine("2. Выслушать.");
                                    Console.WriteLine();
                                    input1 = Console.ReadLine();
                                    Console.Clear();
                                    if (!(input1 == "1" || input1 == "2")) continue;
                                    if (input1 == "1")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("БАМ");
                                            Console.WriteLine("Тело Лили упало замертво, а вы совершили чудовищный поступок, и это будет преследовать вас до конца ваших недолгих дней.");
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (guests[i, 0] == "Лили") guests[i, 2] = "Устранённый";
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("1. Похоронить невинное маленькое тело.");
                                            Console.WriteLine();
                                            input1 = Console.ReadLine();
                                            Console.Clear();
                                            if (!(input1 == "1")) continue;
                                            return lostEnergy;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Лили: Ого, не разу не видела такую пушку! А где вы её остали?");
                                        Console.WriteLine();
                                        Console.WriteLine("1. Боже, я ужасен.");
                                        Console.WriteLine();
                                        input1 = Console.ReadLine();
                                        Console.Clear();
                                        if (!(input1 == "1")) continue;
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            continue;
                        }
                        if (input1 == "4")
                        {
                            while (true)
                            {
                                Console.WriteLine("Лили: Вот");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Лили были обычными белыми детскими глазами.");
                                Console.WriteLine();
                                Console.WriteLine("Лили: Папа говорил, что если долго смотреть в глаза, то можно прочитать чужие мысли? Какое число я загадала?");
                                Console.WriteLine();
                                Console.WriteLine("1. Не знаю.");
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            lostEnergy++;
                            continue;
                        }
                        if (input1 == "5")
                        {
                            while (true)
                            {
                                Console.WriteLine("Лили: Папа говорил, что руки надо мыть каждый день и каждый раз, когда возвращаюсь с прогулки.");
                                Console.WriteLine();
                                Console.WriteLine("Руки Лили были идеально чистыми.");
                                Console.WriteLine();
                                Console.WriteLine("Лили: Вот.");
                                Console.WriteLine();
                                Console.WriteLine("1. Хорошо.");
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            lostEnergy++;
                            continue;
                        }
                    }
                    break;
                case "Вячеслав":
                    while (true)
                    {
                        Console.WriteLine("Вячеслав: Если вам нужна помощь, то обращайтесь.");
                        Console.WriteLine();
                        Console.WriteLine("1. Назад");
                        Console.WriteLine("2. Я не заражусь этим ГОСТ?");
                        if (lostEnergy < energy) Console.WriteLine("3. Проверить зубы (-1 энергия)");
                        if (iteration >= 4 && lostEnergy < energy) Console.WriteLine("4. Проверить глаза (-1 энергия)");
                        if (iteration == 6 && lostEnergy < energy) Console.WriteLine("5. Проверить руки (-1 энергия)");
                        Console.WriteLine();
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        if (!(input1 == "1" || input1 == "2" || input1 == "3" || input1 == "4" || input1 == "5")) continue;
                        if ((iteration == 2 && int.Parse(input1) > 3) || (iteration == 4 && int.Parse(input1) > 4) || (lostEnergy >= energy && int.Parse(input1) > 2)) continue;
                        if (input1 == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Вячеслав: Друг мой, G.O.S.T. не передаётся воздушно капельным путём, только через контакт с кровью инфицированого, не было контакта, нет и болезни.");
                                Console.WriteLine();
                                Console.WriteLine("1. Прям груз с плеч.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            continue;
                        }
                        if (input1 == "1") return lostEnergy;
                        if (input1 == "3")
                        {
                            while (true)
                            {
                                Console.WriteLine("Вячеслав: Понимаю ваши опасения. Вот прошу.");
                                Console.WriteLine();
                                Console.WriteLine("Зубы Вячеслава имели желтоватый окрас.");
                                Console.WriteLine();
                                Console.WriteLine("Вячеслав: Вот, задовайте ещё вопросы, пускай у вас не будет сомнений на мой счёт.");
                                Console.WriteLine();
                                Console.WriteLine("1. Хорошо.");
                                Console.WriteLine();
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            lostEnergy++;
                            continue;
                        }
                        if (input1 == "4")
                        {
                            while (true)
                            {
                                Console.WriteLine("Вячелсав: Вот, пожалуйста.");
                                Console.WriteLine();
                                Console.WriteLine("Глаза Вячеслава были белыми.");
                                Console.WriteLine();
                                Console.WriteLine("Вячеслав: Надеюсь теперь вы мне доверяете.");
                                Console.WriteLine();
                                Console.WriteLine("1. Да");
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            lostEnergy++;
                            continue;
                        }
                        if (input1 == "5")
                        {
                            while (true)
                            {
                                Console.WriteLine("Вячеслав: Вот пожалуйста.");
                                Console.WriteLine();
                                Console.WriteLine("Руки Вячеслава чистые, а под пальцами ничего нет.");
                                Console.WriteLine();
                                Console.WriteLine("Вячеслав: Рад, что мы нашли общий язык");
                                Console.WriteLine();
                                Console.WriteLine("1. Да");
                                input1 = Console.ReadLine();
                                Console.Clear();
                                if (!(input1 == "1")) continue;
                                break;
                            }
                            lostEnergy++;
                            continue;
                        }
                    }
                    break;
            }
            return lostEnergy;
        } // Разговор с людьми // Done
        static int CountIllGuests(string[,] guests) // Подсчёт заражённых
        {
            int counter = 0;
            for (int i = 0; i < 12; i++) 
            {
                if (guests[i, 1] == "Гость" && guests[i, 2] == "Живой") counter++;
            }
            return counter;
        } 
    }
}
