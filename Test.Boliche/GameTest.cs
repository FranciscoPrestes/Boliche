﻿using System.Collections.Generic;
using Boliche;
using NUnit.Framework;

namespace Test.Boliche
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;

        [SetUp]
        public void Init()
        {
            _game = new Game();
        }

        [Test]
        public void Deve_lancar_a_primeira_jogada_do_frame_e_nao_pontuar()
        {
            var frame = new Frame(new[] { 1 });

            _game.Adicionar(frame);

            Assert.AreEqual(0, _game.ObterPontuacao());
        }

        [Test]
        public void Deve_lancar_as_duas_jogadas_do_frame()
        {
            var frame = new Frame(new[] { 1, 4 });

            _game.Adicionar(frame);

            Assert.AreEqual(5, _game.ObterPontuacao());
        }

        [Test]
        public void Deve_lancar_a_segunda_jogada_do_frame()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {1, 4}),
                new Frame(new[] {4, 5})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(14, _game.ObterPontuacao());
        }

        [Test]
        public void Nao_deve_pontuar_quando_houver_spare_sem_jogar_proximo_frame()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {1, 4}),
                new Frame(new[] {4, 5}),
                new Frame(new[] {6, 4})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(14, _game.ObterPontuacao());
        }

        [Test]
        public void Deve_pontuar_quando_houver_spare_e_proximo_frame_tiver_jogada()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {1, 4}),
                new Frame(new[] {4, 5}),
                new Frame(new[] {6, 4}),
                new Frame(new[] {5})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(29, _game.ObterPontuacao());
        }

        [Test]
        public void Nao_deve_pontuar_quando_houver_strike_sem_jogar_proximo_frame()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {1, 4}),
                new Frame(new[] {4, 5}),
                new Frame(new[] {6, 4}),
                new Frame(new[] {5, 5}),
                new Frame(new[] {10})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(49, _game.ObterPontuacao());
        }

        [Test]
        public void Nao_deve_pontuar_quando_houver_strike_ou_spare_e_proxima_primeira_jogada_ter_nenhum_pino_derrubado()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {1, 4}),
                new Frame(new[] {5, 5}),
                new Frame(new[] {0})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(5, _game.ObterPontuacao());
        }

        [Test]
        public void Deve_pontuar_quando_houver_strike_ou_spare_e_proxima_primeira_jogada_ter_nenhum_pino_derrubado_e_segunda_jogada_ter_pelo_menos_um_pino_derrubado()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {5, 5}),
                new Frame(new[] {0, 1})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(12, _game.ObterPontuacao());
        }

        [Test]
        public void Deve_pontuar_quando_houver_strike_e_proximo_frame_tiver_jogada()
        {
            var frames = new List<Frame>
            {
                new Frame(new[] {1, 4}),
                new Frame(new[] {4, 5}),
                new Frame(new[] {6, 4}),
                new Frame(new[] {5, 5}),
                new Frame(new[] {10}),
                new Frame(new[] {0, 1})
            };

            _game.Adicionar(frames);

            Assert.AreEqual(61, _game.ObterPontuacao());
        }
    }
}
